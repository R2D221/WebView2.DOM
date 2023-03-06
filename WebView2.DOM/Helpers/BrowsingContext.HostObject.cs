using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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

			private Stack<IEnumerator<Request>> enumerators = new();

			private JsExecutionContext.JavaScriptSide executionContext =>
				browsingContext.RunningExecutionContext.JavaScript;

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

				RunBothLoops(
					state: Pool.Box((eventTargetJson, @event, argsJson)).Obj,
					d: static obj =>
					{
						var (eventTargetJson, @event, argsJson) = Pool.UnboxAndReturn<(string, string, string)>(obj);

						var eventTarget = JsonSerializer.Deserialize<EventTarget>(eventTargetJson, JSON.Options) ?? throw new Exception();
						var args = JsonSerializer.Deserialize<Event>(argsJson, JSON.Options) ?? throw new Exception();

						Events.Raise(eventTarget, @event, args);

						References2.Forget(args);
					});
			}

			public void Call(string callbackId, string parametersJson)
			{
				_ = Flow.JavaScriptStart;

				RunBothLoops(
					state: Pool.Box((callbackId, parametersJson)).Obj,
					d: static obj =>
					{
						var (callbackId, parametersJson) = Pool.UnboxAndReturn<(string, string)>(obj);

						Callbacks.Call(callbackId, parametersJson);
					});
			}

			private void RunBothLoops(SendOrPostCallback d, object? state)
			{
				enumerators.Push(MyInnerEnumerator());
				IEnumerator<Request> MyInnerEnumerator()
				{
					using var executionContext = browsingContext.StartNewExecutionContext();

					browsingContext.browsingSyncContext.PostInternal(
						state: Pool.Box((executionContext, d, state)).Obj,
						d: static param =>
						{
							var (executionContext, d, state) = Pool.UnboxAndReturn<(JsExecutionContext, SendOrPostCallback, object?)>(param);

							using var __ = executionContext.CSharp;

							d(state);
						});

					using var javaScript = executionContext.JavaScript;

					while (javaScript.Requests.WaitToReadAsync(javaScript.cancellationToken).AsTask().GetAwaiter().GetResult())
					{
						while (true)
						{
							if (javaScript.Requests.TryRead(out var request))
							{
								yield return request;
								break;
							}

							javaScript.cancellationToken.ThrowIfCancellationRequested();
						}
					}

					_ = enumerators.Pop();
					yield break;
				}
			}

			public void iterator() { }

			struct next_response
			{
				public bool done { get; set; }
				public object? value { get; set; }
			}

			public string next()
			{
				var enumerator = enumerators.Peek();

				var response = new next_response();

				response.done = enumerator.MoveNext() == false;

				// Type is declared as object? since we need properties
				// of derived classes to be serialized. This is the
				// accepted solution according to
				// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-polymorphism

				response.value = response.done ? null : enumerator.Current;

				return JsonSerializer.Serialize(response, JSON.Options);
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

			public void Forget(string referenceId) =>
				References2.Forget(referenceId);
		}
	}
}
