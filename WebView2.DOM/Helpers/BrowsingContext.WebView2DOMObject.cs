using OneOf;
using System;
using System.Diagnostics;
using System.Text.Json;
using WebView2.DOM.Helpers;

namespace WebView2.DOM
{
	public sealed partial class BrowsingContext
	{
		public static WebView2DOMObject Current =>
			threadLocalBrowsingContext.Value is { } bc
			? new WebView2DOMObject(bc)
			: throw new InvalidOperationException("The current thread doesn't have a browsing context.")
			;

		public struct WebView2DOMObject
		{
			private readonly BrowsingContext browsingContext;

			public WebView2DOMObject(BrowsingContext browsingContext) => this.browsingContext = browsingContext;

			public Window Window => browsingContext.Window;

			private OneOf<string, Exception, @null> Request(Request request)
			{
				Debugger.NotifyOfCrossThreadDependency();

				var channel = DuplexChannel.ThreadLocal.Value ?? throw new Exception();
				var cschannel = channel.GetCSharpChannel();

				var success = cschannel.Requests.TryWrite(request);

				if (success == false)
				{
					Debugger.Break();
					throw new Exception();
				}

				channel.SetDispatcherFrameContinueFalse();

				var @continue = cschannel.Responses.WaitToReadAsync(channel.cts.Token).AsTask().Result;

				if (@continue)
				{
					while (true)
					{
						if (cschannel.Responses.TryRead(out var response))
						{
							return response;
						}
					}
				}
				else
				{
					throw new Exception();
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
		}
	}
}
