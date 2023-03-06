using OneOf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Threading;
using WebView2.DOM.Helpers;
using static WebView2.DOM.BrowsingContext;

namespace WebView2.DOM
{
	internal sealed class JsExecutionContext : IDisposable
	{
		private static Channel<T> CreateChannel<T>() => Channel.CreateBounded<T>(options: new(capacity: 1) { SingleReader = true, SingleWriter = true, AllowSynchronousContinuations = true });

		private readonly BrowsingContext browsingContext;
		private readonly TaskCompletionSource<DispatcherFrame> dispatcherFrameTcs = new();
		private readonly TaskCompletionSource tcs = new();
		private readonly CancellationTokenSource cts = new();
		private readonly Channel<Request> requests = CreateChannel<Request>();
		private readonly Channel<OneOf<string, Exception, @null>> responses = CreateChannel<OneOf<string, Exception, @null>>();

		internal CSharpSide CSharp { get; }
		internal JavaScriptSide JavaScript { get; }

		public JsExecutionContext(BrowsingContext browsingContext)
		{
			this.browsingContext = browsingContext;

			CSharp = new(this);
			JavaScript = new(this);
		}

		public void Dispose()
		{
			cts.Cancel();
			CSharp.Dispose();
			JavaScript.Dispose();

			tcs.Task.GetAwaiter().GetResult();

			browsingContext.EndExecutionContext(this);
		}

		internal sealed class CSharpSide : IDisposable
		{
			private readonly JsExecutionContext jsExecutionContext;
			private CancellationToken cancellationToken => jsExecutionContext.cts.Token;
			internal TaskCompletionSource taskCompletionSource => jsExecutionContext.tcs;

			public ChannelWriter<Request> Requests =>
				jsExecutionContext.requests.Writer;

			public ChannelReader<OneOf<string, Exception, @null>> Responses =>
				jsExecutionContext.responses.Reader;

			public CSharpSide(JsExecutionContext jsExecutionContext)
			{
				this.jsExecutionContext = jsExecutionContext;
			}

			private void DispatcherPushFrame()
			{
				if (jsExecutionContext.dispatcherFrameTcs.Task.IsCompleted == false)
				{
					jsExecutionContext.dispatcherFrameTcs.SetResult(new DispatcherFrame());
				}

				var dispatcherFrame = jsExecutionContext.dispatcherFrameTcs.Task.GetAwaiter().GetResult();
				Dispatcher.PushFrame(dispatcherFrame);
				dispatcherFrame.Continue = true;
			}

			private OneOf<string, Exception, @null> Request(Request request)
			{
				Debugger.NotifyOfCrossThreadDependency();

				cancellationToken.ThrowIfCancellationRequested();

				var success = Requests.TryWrite(request);

				if (success == false)
				{
					throw new OperationCanceledException();
				}

				DispatcherPushFrame();
				var @continue = Responses.WaitToReadAsync(cancellationToken).AsTask().GetAwaiter().GetResult();

				if (@continue)
				{
					while (true)
					{
						if (Responses.TryRead(out var response))
						{
							return response;
						}

						cancellationToken.ThrowIfCancellationRequested();
					}
				}
				else
				{
					throw new OperationCanceledException();
				}
			}

			public void Construct(JsObject obj, string typeName, object?[] args)
			{
				using var request = BrowsingContext.Request.Constructor.FromPool(typeName, args);
				var response = Request(request);

				response.Switch
					(
					(string referenceId) => References2.SetId(obj, referenceId),
					(Exception ex) => throw ex,
					_ => throw new Exception()
					);
			}

			public T Get<T>(JsObject obj, string property)
			{
				using var request = BrowsingContext.Request.Get.FromPool(obj, property);
				var response = Request(request);

				return response.Match
					(
					(string json) => JsonSerializer.Deserialize<T>(json, JSON.Options)!,
					(Exception ex) => throw ex,
					_ => throw new Exception()
					);
			}

			public T Get<T>(JsObject obj, uint index)
			{
				using var request = BrowsingContext.Request.GetUintIndex.FromPool(obj, index);
				var response = Request(request);

				return response.Match
					(
					(string json) => JsonSerializer.Deserialize<T>(json, JSON.Options)!,
					(Exception ex) => throw ex,
					_ => throw new Exception()
					);
			}

			public T Get<T>(JsObject obj, int index)
			{
				using var request = BrowsingContext.Request.GetIntIndex.FromPool(obj, index);
				var response = Request(request);

				return response.Match
					(
					(string json) => JsonSerializer.Deserialize<T>(json, JSON.Options)!,
					(Exception ex) => throw ex,
					_ => throw new Exception()
					);
			}

			public void Set<T>(JsObject obj, string property, T value)
			{
				using var request = BrowsingContext.Request.Set<T>.FromPool(obj, property, value);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public void Set<T>(JsObject obj, uint index, T value)
			{
				using var request = BrowsingContext.Request.SetUintIndex<T>.FromPool(obj, index, value);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public void Set<T>(JsObject obj, int index, T value)
			{
				using var request = BrowsingContext.Request.SetIntIndex<T>.FromPool(obj, index, value);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public void Delete(JsObject obj, string property)
			{
				using var request = BrowsingContext.Request.Delete.FromPool(obj, property);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public void Delete(JsObject obj, uint index)
			{
				using var request = BrowsingContext.Request.DeleteUintIndex.FromPool(obj, index);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public void Delete(JsObject obj, int index)
			{
				using var request = BrowsingContext.Request.DeleteIntIndex.FromPool(obj, index);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public void InvokeVoid(JsObject obj, string method, object?[] args)
			{
				using var request = BrowsingContext.Request.Invoke.FromPool(obj, method, args);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public T Invoke<T>(JsObject obj, string method, object?[] args)
			{
				using var request = BrowsingContext.Request.Invoke.FromPool(obj, method, args);
				var response = Request(request);

				return response.Match
					(
					(string json) => JsonSerializer.Deserialize<T>(json, JSON.Options)!,
					(Exception ex) => throw ex,
					_ => throw new Exception()
					);
			}

			public T SymbolInvoke<T>(JsObject obj, string method, object?[] args)
			{
				using var request = BrowsingContext.Request.SymbolInvoke.FromPool(obj, method, args);
				var response = Request(request);

				return response.Match
					(
					(string json) => JsonSerializer.Deserialize<T>(json, JSON.Options)!,
					(Exception ex) => throw ex,
					_ => throw new Exception()
					);
			}

			public void AddEvent<T>(EventTarget obj, string @event, EventHandler<T>? handler)
				where T : Event
			{
				Events.Add(obj, @event, handler, out var shouldAttach);

				if (shouldAttach)
				{
					using var request = BrowsingContext.Request.AddEvent.FromPool(obj, @event);
					var response = Request(request);

					response.Switch
						(
						(string json) => throw new Exception(),
						(Exception ex) => throw ex,
						_ => { }
						);
				}
			}

			public void RemoveEvent<T>(EventTarget obj, string @event, EventHandler<T>? handler)
				where T : Event
			{
				Events.Remove(obj, @event, handler, out var shouldDetach);

				if (shouldDetach)
				{
					using var request = BrowsingContext.Request.RemoveEvent.FromPool(obj, @event);
					var response = Request(request);

					response.Switch
						(
						(string json) => throw new Exception(),
						(Exception ex) => throw ex,
						_ => { }
						);
				}
			}

			public void Return(object? returnValue)
			{
				using var request = BrowsingContext.Request.Return.FromPool(returnValue);
				var response = Request(request);

				response.Switch
					(
					(string json) => throw new Exception(),
					(Exception ex) => throw ex,
					_ => { }
					);
			}

			public void Dispose()
			{
				_ = taskCompletionSource.TrySetResult();
				_ = Requests.TryComplete();
			}
		}

		internal sealed class JavaScriptSide : IDisposable
		{
			private readonly JsExecutionContext jsExecutionContext;
			internal CancellationToken cancellationToken => jsExecutionContext.cts.Token;

			public ChannelReader<Request> Requests =>
				jsExecutionContext.requests.Reader;

			public ChannelWriter<OneOf<string, Exception, @null>> Responses =>
				jsExecutionContext.responses.Writer;

			public JavaScriptSide(JsExecutionContext jsExecutionContext)
			{
				this.jsExecutionContext = jsExecutionContext;
			}

			internal void WriteResponse(OneOf<string, Exception, @null> value)
			{
				var success = Responses.TryWrite(value);
				SetDispatcherFrameContinueFalse();

				Debug.Assert(success);
			}

			public void SetDispatcherFrameContinueFalse()
			{
				var dispatcherFrame = jsExecutionContext.dispatcherFrameTcs.Task.GetAwaiter().GetResult();
				dispatcherFrame.Continue = false;
			}

			internal void DoEvents()
			{
				if (SynchronizationContext.Current is not System.Windows.Forms.WindowsFormsSynchronizationContext) { return; }

				System.Windows.Forms.Application.DoEvents();
			}

			public void Dispose()
			{
				_ = Responses.TryComplete();
			}
		}
	}
}