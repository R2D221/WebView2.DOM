using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Tact;
using Tact.Reflection;
using WebView2.DOM.Helpers;

namespace WebView2.DOM
{
	internal static class References2
	{
		//private static readonly TypeConversionProvider typeConversionProvider = new();

		private static readonly Dictionary<string, Type> types =
			typeof(Window).Assembly
			.GetTypes()
			.Where(x => x.IsClass && typeof(JsObject).IsAssignableFrom(x))
			.ToDictionary(
				type => type.FullName!.Substring(type.Namespace!.Length + 1).Replace("+", " ") switch
				{
					"JsObject" => "Object",
					var x => x,
				},
				type => type
			);

		private static readonly ConditionalWeakTable<JsObject, string>
			objToId = new();
		private static readonly ConcurrentDictionary<string, WeakReference<JsObject>>
			idToObj = new();
		private static readonly FinalizationRegistry<JsObject, (IWebView2 webView, string referenceId)>
			registry = new(x =>
			{
				x.webView.BeginInvoke(() =>
				{
					_ =
						x.webView.GetCoreWebView2()
						.ExecuteScriptAsync($"WebView2DOM.FreeCSharpRef({JsonSerializer.Serialize(x.referenceId)})");
				});
			});

		//private static HashSet<string> seen = new();

		public static TJsObject Load<TJsObject>(string referenceId, string typeName)
			where TJsObject : JsObject
		{
			//if (seen.Add(typeName))
			//{
			//	//Debugger.Break();
			//}

			var weakRef = idToObj.GetOrAdd(referenceId, _ => new(null!));

			if (!weakRef.TryGetTarget(out var target))
			{
				if (!types.TryGetValue(typeName, out var realType))
				{
					throw new Exception($"Type {typeName} could not be mapped.");
				}

				var requestedType = typeof(TJsObject);

				Type type;

				if (realType.IsAssignableFrom(requestedType))
				{
					type = requestedType;
				}
				else
				{
					type = realType;
				}

				target = (JsObject)
#if NETFRAMEWORK
					System.Runtime.Serialization.FormatterServices
#else
					System.Runtime.CompilerServices.RuntimeHelpers
#endif
					.GetUninitializedObject(type);

				weakRef.SetTarget(target);

				objToId.Add(target, referenceId);
				registry.Register(target, (BrowsingContext.Current.webView, referenceId));
			}

			return (TJsObject)target;
		}

		public static string GetId(JsObject obj)
		{
			if (objToId.TryGetValue(obj, out var referenceId))
			{
				return referenceId;
			}
			else
			{
				throw new Exception();
			}
		}

		public static void SetId(JsObject obj, string referenceId)
		{
			objToId.Add(obj, referenceId);
			idToObj[referenceId] = new(obj);
		}

		public static void Forget(JsObject obj)
		{
			var id = GetId(obj);
			_ = objToId.Remove(obj);
			_ = idToObj.TryRemove(id, out _);
			registry.Unregister(obj);
		}

		public static void Forget(string referenceId)
		{
			if (!idToObj.TryRemove(referenceId, out var weakRef))
			{
				return;
			}

			if (weakRef.TryGetTarget(out var target))
			{
				Debugger.Break();

				_ = objToId.Remove(target);
				registry.Unregister(target);
			}
		}
	}

	internal static class Events
	{

		private static readonly ConcurrentDictionary<(string referenceId, string @event), ConcurrentDictionary<Delegate, object?>>
			events = new();

		public static void Add<T>(EventTarget obj, string @event, EventHandler<T>? handler, out bool shouldAttach)
			where T : Event
		{
			shouldAttach = false;
			if (handler is null) { return; }

			var handlers = events.GetOrAdd((References2.GetId(obj), @event), _ => new());

			if (handlers.Count == 0)
			{
				shouldAttach = true;
			}

			handlers[handler] = null;
		}

		public static void Remove<T>(EventTarget obj, string @event, EventHandler<T>? handler, out bool shouldDetach)
			where T : Event
		{
			shouldDetach = false;
			if (handler is null) { return; }

			if (!events.TryGetValue((References2.GetId(obj), @event), out var handlers)) { return; }

			_ = handlers.TryRemove(handler, out _);

			if (handlers.Count == 0)
			{
				shouldDetach = true;
			}
		}

		public static void Raise(EventTarget eventTarget, string @event, Event args)
		{
			if (!events.TryGetValue((References2.GetId(eventTarget), @event), out var handlers)) { return; }

			try
			{
				foreach (var handler in handlers.Keys)
				{
					args.Invoke(eventTarget, handler);
				}
			}
			catch (TargetInvocationException ex)
			{
				ExceptionDispatchInfo
					.Capture(ex.InnerException!)
					.Throw();

				throw;
			}
		}
	}

	internal static class Callbacks
	{
		private static readonly ConditionalWeakTable<Delegate, string> callbackToId = new();
		private static readonly ConcurrentDictionary<string, Delegate> idToCallback = new();

		private static readonly ConditionalWeakTable<Type, ParameterInfo[]> parametersInfoCache = new();

		public static string Register(Delegate callback)
		{
			return callbackToId.GetValue(callback, static _callback =>
			{
				var id = Guid.NewGuid().ToString();
				idToCallback[id] = _callback;
				return id;
			});
		}

		public static void Call(string callbackId, string parametersJson)
		{
			if (!idToCallback.TryGetValue(callbackId, out var callback)) { throw new Exception(); }

			var parameters =
				JsonSerializer.Deserialize<ImmutableArray<JsonElement>?>(parametersJson, JSON.Options)
				?? ImmutableArray<JsonElement>.Empty;

			var parametersInfo =
				parametersInfoCache.GetValue
				(
					callback.GetType(),
					_ => callback.Method.GetParameters()
				);

			if (parametersInfo.Length != parameters.Length)
			{
				throw new InvalidOperationException("Error invoking callback: number of parameters doesn't match");
			}

			var final =
				Enumerable.Zip(
					parameters,
					parametersInfo,
					(param, info) =>
						JsonSerializer.Deserialize(param, info.ParameterType, JSON.Options)
				)
				.ToArray();

			try
			{
				var result = EfficientInvoker.ForDelegate(callback).Invoke(callback, args: final);
				//var result = callback.DynamicInvoke(args: final);

				var context = BrowsingContext.Current.RunningExecutionContext.CSharp;
				context.Return(result);
				_ = context.Requests.TryComplete();
			}
			catch (TargetInvocationException ex)
			{
				ExceptionDispatchInfo
					.Capture(ex.InnerException!)
					.Throw();

				throw;
			}
		}

		public static void Forget(string callbackId)
		{
			if (!idToCallback.TryRemove(callbackId, out var callback)) { return; }
			_ = callbackToId.Remove(callback);
		}
	}

	internal static class Promises
	{
		//public static Task 
	}
}
