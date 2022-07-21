using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using WebView2.DOM.Helpers;

namespace WebView2.DOM
{
	public sealed partial class BrowsingContext
	{
		public class _HostObject
		{
			private readonly BrowsingContext browsingContext;

			internal _HostObject(BrowsingContext browsingContext)
			{
				this.browsingContext = browsingContext;
			}

			public string GetWindowId()
			{
				return References2.GetId(browsingContext.Window);
			}

			private IEnumerator<Request>? enumerator;

			private JsExecutionContext.JavaScriptSide executionContext =>
				browsingContext.RunningExecutionContext?.JavaScript
				?? throw new InvalidOperationException();

			public void Run()
			{
				_ = Flow.JavaScriptStart;

				var success = browsingContext.callbacksChannel.Reader.TryRead(out var action);
				if (!success) { throw new Exception(); }

				RunBothLoops(action.d, action.state);
			}

			public void RaiseEvent(string eventTargetJson, string @event, string argsJson)
			{
				_ = Flow.JavaScriptStart;

				var eventTarget = JsonSerializer.Deserialize<EventTarget>(eventTargetJson, JSON.Options);
				var args = JsonSerializer.Deserialize<Event>(argsJson, JSON.Options);

				RunBothLoops(
					state: Pool.Box((eventTarget, @event, args)),
					d: static obj =>
					{
						var (eventTarget, @event, args) = Pool.UnboxAndReturn<(EventTarget, string, Event)>(obj);

						Events.Raise(eventTarget, @event, args);

						References2.Forget(args);
					});
			}

			public void Call(string callbackId, string parametersJson)
			{
				_ = Flow.JavaScriptStart;

				RunBothLoops(
					state: Pool.Box((callbackId, parametersJson)),
					d: static obj =>
					{
						var (callbackId, parametersJson) = Pool.UnboxAndReturn<(string, string)>(obj);

						Callbacks.Call(callbackId, parametersJson);
					});
			}

			private void RunBothLoops(SendOrPostCallback d, object? state)
			{
				enumerator = MyInnerEnumerator();
				IEnumerator<Request> MyInnerEnumerator()
				{
					using var executionContext = browsingContext.StartNewExecutionContext();

					browsingContext.browsingSyncContext.PostInternal(
						state: Pool.Box((executionContext, d, state)),
						d: static param =>
						{
							var (executionContext, d, state) = Pool.UnboxAndReturn<(JsExecutionContext, SendOrPostCallback, object?)>(param);

							using var __ = executionContext.CSharp;

							try
							{
								d(state);
							}
							finally
							{
								executionContext.CSharp.taskCompletionSource.SetResult();
							}
						});

					using var javaScript = executionContext.JavaScript;

					while (javaScript.Requests.Completion.IsCompleted == false)
					{
						javaScript.DispatcherPushFrame();

						javaScript.cancellationToken.ThrowIfCancellationRequested();

						while (true)
						{
							if (javaScript.Requests.TryRead(out var request))
							{
								yield return request;
								break;
							}
							else if (javaScript.Requests.Completion.IsCompleted)
							{
								break;
							}
							else
							{
								javaScript.DoEvents();
							}

							javaScript.cancellationToken.ThrowIfCancellationRequested();
						}
					}

					enumerator = null;
					yield break;
				}
			}

			public void iterator() { }

			public string next()
			{
				var enumerator = this.enumerator ?? throw new Exception();

				var done = enumerator.MoveNext() == false;

				// Type is declared as object? since we need properties
				// of derived classes to be serialized. This is the
				// accepted solution according to
				// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-polymorphism

				object? value = done ? null : enumerator.Current;

				return JsonSerializer.Serialize(new { done, value }, JSON.Options);
			}

			public void ReturnVoid()
			{
				executionContext.WriteResponse(@null.Value);
			}

			public void ReturnValue(string? json)
			{
				if (json is null) { Debugger.Break(); }
				executionContext.WriteResponse(json ?? "null");
			}

			public void Throw(string? json)
			{
				var errorWrapper = JsonSerializer.Deserialize<ErrorWrapper>(json ?? "null", JSON.Options);
				var exception = errorWrapper?.GetException() ?? (Exception)new NullReferenceException();

				executionContext.WriteResponse(exception);
			}

			public void ForgetCallback(string callbackId)
			{
				Callbacks.Forget(callbackId);
			}

			public void References_Remove() => throw new NotImplementedException();
		}
	}
}
