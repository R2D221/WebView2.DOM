using Microsoft.Extensions.ObjectPool;
using OneOf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using WebView2.DOM.Helpers;
using static WebView2.DOM.BrowsingContext;

namespace WebView2.DOM
{
	internal static class Pool
	{
		// based on PooledAwait.Pool
		// https://github.com/mgravell/PooledAwait/blob/master/src/PooledAwait/Pool.cs

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object Box<T>(in T value) where T : struct
			=> ItemBox<T>.Create(in value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T UnboxAndReturn<T>(object? obj) where T : struct
			=> ItemBox<T>.UnboxAndReturn(obj);

		internal sealed class ItemBox<T> where T : struct
		{
			private static readonly ObjectPool<ItemBox<T>> pool = new DefaultObjectPool<ItemBox<T>>(new DefaultPooledObjectPolicy<ItemBox<T>>());

			private T _value;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static ItemBox<T> Create(in T value)
			{
				var box = pool.Get();
				box._value = value;
				return box;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static T UnboxAndReturn(object? obj)
			{
				var box = (ItemBox<T>)obj!;
				var value = box._value;
				box._value = default;
				pool.Return(box);
				return value;
			}
		}
	}

	public sealed partial class BrowsingContext
	{
		public _HostObject HostObject => new _HostObject(this);

		public class _HostObject
		{
			private readonly BrowsingContext browsingContext;

			public _HostObject(BrowsingContext browsingContext)
			{
				this.browsingContext = browsingContext;
			}

			public string GetWindowId()
			{
				return References2.GetId(browsingContext.Window);
			}

			private void DoEvents()
			{
				if (browsingContext.uiSyncContext is not System.Windows.Forms.WindowsFormsSynchronizationContext) { return; }

				System.Windows.Forms.Application.DoEvents();
			}

			private DuplexChannel? duplexChannel;
			//private readonly ConcurrentDictionary<long, IEnumerator<Request>> enumerators = new();
			private IEnumerator<Request>? enumerator;

			private IEnumerator<Request> MyEnumerator()
			{
				var channel = duplexChannel ?? throw new Exception();
				var jschannel = channel.GetJavaScriptChannel();

				while (true)
				{
					channel.DispatcherPushFrame();

					while (true)
					{
						if (jschannel.Requests.TryRead(out var request))
						{
							yield return request;
						}
						else if (jschannel.Requests.Completion.IsCompleted)
						{
							_ = Flow.JavaScriptEnd;

							_ = jschannel.Responses.TryComplete();
							duplexChannel = null;
							enumerator = null;
							yield break;
						}
						else
						{
							DoEvents();
						}
					}
				}
			}

			public void iterator2()
			{
				enumerator = MyEnumerator();
			}

			public string next2()
			{
				var enumerator = (this.enumerator ?? throw new Exception());

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
				var channel = (duplexChannel ?? throw new Exception()).GetJavaScriptChannel();
				var success = channel.Responses.TryWrite(@null.Value);

				if (success == false)
				{
					Debugger.Break();
					throw new Exception();
				}
			}

			public void ReturnValue(string? json)
			{
				var channel = (duplexChannel ?? throw new Exception()).GetJavaScriptChannel();
				var success = channel.Responses.TryWrite(json ?? "null");

				if (success == false)
				{
					Debugger.Break();
					throw new Exception();
				}
			}

			public void Throw(string? json)
			{
				var errorWrapper = JsonSerializer.Deserialize<ErrorWrapper>(json ?? "null", JSON.Options);

				var channel = (duplexChannel ?? throw new Exception()).GetJavaScriptChannel();
				var success = channel.Responses.TryWrite(errorWrapper?.GetException() ?? (Exception)new NullReferenceException());

				if (success == false)
				{
					Debugger.Break();
					throw new Exception();
				}
			}

			public void Run()
			{
				_ = Flow.JavaScriptStart;

				var success = browsingContext.callbacksChannel.Reader.TryRead(out var action);

				if (!success) { throw new Exception(); }

				var channel = browsingContext.innerSyncContext.RunJsCallback(action.d, action.state);

				this.duplexChannel = channel;
			}

			public void RaiseEvent(string eventTargetJson, string @event, string argsJson)
			{
				_ = Flow.JavaScriptStart;

				var eventTarget = JsonSerializer.Deserialize<EventTarget>(eventTargetJson, JSON.Options);
				var args = JsonSerializer.Deserialize<Event>(argsJson, JSON.Options);

				var channel = browsingContext.innerSyncContext.RunJsCallback(
					state: Pool.Box((eventTarget, @event, args)),
					d: static obj =>
					{
						var (eventTarget, @event, args) = Pool.UnboxAndReturn<(EventTarget, string, Event)>(obj);

						Events.Raise(eventTarget, @event, args);

						References2.Forget(args);
					});

				this.duplexChannel = channel;
			}

			public void Call(string callbackId, string parametersJson)
			{
				_ = Flow.JavaScriptStart;

				var channel = browsingContext.innerSyncContext.RunJsCallback(
					state: Pool.Box((callbackId, parametersJson)),
					d: static obj =>
					{
						var (callbackId, parametersJson) = Pool.UnboxAndReturn<(string, string)>(obj);

						Callbacks.Call(callbackId, parametersJson);
					});

				this.duplexChannel = channel;
			}

			public void ForgetCallback(string callbackId)
			{
				Callbacks.Forget(callbackId);
			}






































			public void References_Remove() => throw new NotImplementedException();
		}
	}
}
