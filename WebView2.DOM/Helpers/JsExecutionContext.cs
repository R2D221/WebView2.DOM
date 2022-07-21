using OneOf;
using System;
using System.Diagnostics;
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

		private BrowsingContext browsingContext;
		private readonly DispatcherFrame? dispatcherFrame;
		private readonly TaskCompletionSource tcs = new();
		private readonly CancellationTokenSource cts = new();
		private Channel<Request> requests = CreateChannel<Request>();
		private Channel<OneOf<string, Exception, @null>> responses = CreateChannel<OneOf<string, Exception, @null>>();

		internal CSharpSide CSharp { get; }
		internal JavaScriptSide JavaScript { get; }

		public JsExecutionContext(BrowsingContext browsingContext)
		{
			this.browsingContext = browsingContext;

			dispatcherFrame =
				browsingContext.uiSyncContext is DispatcherSynchronizationContext
				? new DispatcherFrame()
				: null
				;

			CSharp = new(this);
			JavaScript = new(this);
		}

		public void Dispose()
		{
			cts.Cancel();
			if (dispatcherFrame is not null) { dispatcherFrame.Continue = true; }

			CSharp.Dispose();
			JavaScript.Dispose();

			tcs.Task.GetAwaiter().GetResult();

			browsingContext.EndExecutionContext(this);
		}

		internal sealed class CSharpSide : IDisposable
		{
			private readonly Lazy<object?> disposeLazy;
			private readonly JsExecutionContext jsExecutionContext;
			private DispatcherFrame? dispatcherFrame => jsExecutionContext.dispatcherFrame;
			private CancellationToken cancellationToken => jsExecutionContext.cts.Token;
			internal TaskCompletionSource taskCompletionSource => jsExecutionContext.tcs;

			public ChannelWriter<Request> Requests =>
				jsExecutionContext.requests.Writer;

			public ChannelReader<OneOf<string, Exception, @null>> Responses =>
				jsExecutionContext.responses.Reader;

			public CSharpSide(JsExecutionContext jsExecutionContext)
			{
				this.jsExecutionContext = jsExecutionContext;
				disposeLazy = new(() => { DisposeInner(); return null; });
			}

			private void SetDispatcherFrameContinueFalse()
			{
				if (dispatcherFrame is null) { return; }

				dispatcherFrame.Continue = false;
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

				SetDispatcherFrameContinueFalse();

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
				var request = new Request.Constructor(null!, typeName, args);
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
				var request = new Request.Get(obj, property);
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
				var request = new Request.GetUintIndex(obj, index);
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
				var request = new Request.GetIntIndex(obj, index);
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
				var request = new Request.Set<T>(obj, property, value);
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
				var request = new Request.SetUintIndex<T>(obj, index, value);
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
				var request = new Request.SetIntIndex<T>(obj, index, value);
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
				var request = new Request.Delete(obj, property);
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
				var request = new Request.DeleteUintIndex(obj, index);
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
				var request = new Request.DeleteIntIndex(obj, index);
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
				var request = new Request.Invoke(obj, method, args);
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
				var request = new Request.Invoke(obj, method, args);
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
				var request = new Request.SymbolInvoke(obj, method, args);
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
					var request = new Request.AddEvent(obj, @event);
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
					var request = new Request.RemoveEvent(obj, @event);
					var response = Request(request);

					response.Switch
						(
						(string json) => throw new Exception(),
						(Exception ex) => throw ex,
						_ => { }
						);
				}
			}

			public void DisposeInner()
			{
				_ = Requests.TryComplete();
				SetDispatcherFrameContinueFalse();
			}

			public void Dispose() => _ = disposeLazy.Value;
		}

		internal sealed class JavaScriptSide : IDisposable
		{
			private readonly Lazy<object?> disposeLazy;
			private readonly JsExecutionContext jsExecutionContext;
			private DispatcherFrame? dispatcherFrame => jsExecutionContext.dispatcherFrame;
			internal CancellationToken cancellationToken => jsExecutionContext.cts.Token;

			public ChannelReader<Request> Requests =>
				jsExecutionContext.requests.Reader;

			public ChannelWriter<OneOf<string, Exception, @null>> Responses =>
				jsExecutionContext.responses.Writer;

			public JavaScriptSide(JsExecutionContext jsExecutionContext)
			{
				this.jsExecutionContext = jsExecutionContext;
				disposeLazy = new(() => { DisposeInner(); return null; });
			}

			internal void WriteResponse(OneOf<string, Exception, @null> value)
			{
				var success = Responses.TryWrite(value);

				if (success == false)
				{
					Debugger.Break();
					throw new Exception();
				}
			}

			internal void DispatcherPushFrame()
			{
				if (dispatcherFrame is null) { return; }

				Dispatcher.PushFrame(dispatcherFrame);
				dispatcherFrame.Continue = true;
			}

			internal void DoEvents()
			{
				if (SynchronizationContext.Current is not System.Windows.Forms.WindowsFormsSynchronizationContext) { return; }

				System.Windows.Forms.Application.DoEvents();
			}

			public void DisposeInner()
			{
				_ = Responses.TryComplete();
			}

			public void Dispose() => _ = disposeLazy.Value;
		}
	}
}