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
	internal static class References
	{
		public static Task<string> GetTask(string promiseId) => throw new NotImplementedException();
	}

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

		public static TJsObject Load<TJsObject>(string referenceId, string typeName)
			where TJsObject : JsObject
		{
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

	//public sealed class References
	//{
	//	private static readonly TypeConversionProvider typeConversionProvider = new();

	//	private static readonly ConcurrentDictionary<string, TaskCompletionSource<string>>
	//		tcsRefs = new();
		
	//	private static readonly ConcurrentDictionary<string, Task<string>>
	//		taskRefs = new();
		
	//	private static readonly ConcurrentDictionary<string, (Func<string, JsObject> constructor, WeakReference<JsObject> @ref)>
	//		objRefs = new();
		
	//	private static readonly ConcurrentDictionary<string, Delegate>
	//		callbackRefs = new();

	//	internal static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, Delegate?>>
	//		events = new();

	//	private readonly Dictionary<string, Func<string, JsObject>> types;

	//	internal References(CoreWebView2 coreWebView)
	//	{
	//		var t1 =
	//			typeof(Window).Assembly
	//			.GetTypes()
	//			.Where(x => x.IsClass && typeof(JsObject).IsAssignableFrom(x))
	//			.ToDictionary(
	//				type => type.Name switch
	//				{
	//					"JsObject" => "Object",
	//					_ => type.Name,
	//				},
	//				type => (Func<string, JsObject>)
	//				(
	//					(id) =>
	//						(JsObject)Activator.CreateInstance(
	//						type: type,
	//						bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance,
	//						binder: null,
	//						args: new object?[] { coreWebView, id },
	//						culture: null)!
	//				)
	//			);

	//		var t2 = new Dictionary<string, Func<string, JsObject>>
	//		{
	//			["hidden"/*         */] = (id) => new HTMLHiddenInputElement/*        */(coreWebView, id),
	//			["text"/*           */] = (id) => new HTMLTextInputElement/*          */(coreWebView, id),
	//			["search"/*         */] = (id) => new HTMLSearchInputElement/*        */(coreWebView, id),
	//			["tel"/*            */] = (id) => new HTMLTelephoneInputElement/*     */(coreWebView, id),
	//			["url"/*            */] = (id) => new HTMLURLInputElement/*           */(coreWebView, id),
	//			["email"/*          */] = (id) => new HTMLEmailInputElement/*         */(coreWebView, id),
	//			["password"/*       */] = (id) => new HTMLPasswordInputElement/*      */(coreWebView, id),
	//			["date"/*           */] = (id) => new HTMLDateInputElement/*          */(coreWebView, id),
	//			["month"/*          */] = (id) => new HTMLMonthInputElement/*         */(coreWebView, id),
	//			["week"/*           */] = (id) => new HTMLWeekInputElement/*          */(coreWebView, id),
	//			["time"/*           */] = (id) => new HTMLTimeInputElement/*          */(coreWebView, id),
	//			["datetime-local"/* */] = (id) => new HTMLLocalDateTimeInputElement/* */(coreWebView, id),
	//			["number"/*         */] = (id) => new HTMLNumberInputElement/*        */(coreWebView, id),
	//			["range"/*          */] = (id) => new HTMLRangeInputElement/*         */(coreWebView, id),
	//			["color"/*          */] = (id) => new HTMLColorInputElement/*         */(coreWebView, id),
	//			["checkbox"/*       */] = (id) => new HTMLCheckboxInputElement/*      */(coreWebView, id),
	//			["radio"/*          */] = (id) => new HTMLRadioButtonInputElement/*   */(coreWebView, id),
	//			["file"/*           */] = (id) => new HTMLFileUploadInputElement/*    */(coreWebView, id),
	//			["submit"/*         */] = (id) => new HTMLSubmitInputElement/*        */(coreWebView, id),
	//			["image"/*          */] = (id) => new HTMLImageInputElement/*         */(coreWebView, id),
	//			["reset"/*          */] = (id) => new HTMLResetInputElement/*         */(coreWebView, id),
	//			["button"/*         */] = (id) => new HTMLButtonInputElement/*        */(coreWebView, id),
	//		};

	//		types = t1.Concat(t2).ToDictionary(x => x.Key, x => x.Value);
	//	}

	//	#region Called from JavaScript
	//	public void Add(string id, string type) =>
	//		objRefs.AddOrUpdate(id,
	//			_ => types.TryGetValue(type, out var constructor)
	//				? (constructor, new WeakReference<JsObject>(constructor(id)))
	//				: throw new InvalidOperationException($"JavaScript type {type} not found in C#"),
	//			(_, __) => throw new InvalidOperationException()
	//			);

	//	public void AddHTMLInputElement(string id, string type) =>
	//		objRefs.AddOrUpdate(id,
	//			_ => types.TryGetValue(type, out var constructor)
	//				? (constructor, new WeakReference<JsObject>(constructor(id)))
	//				: throw new InvalidOperationException($"HTMLInputElement of type {type} not found in C#"),
	//			(_, __) => throw new InvalidOperationException()
	//			);

	//	public void Remove(string id)
	//	{
	//		_ = objRefs.TryRemove(id, out _);
	//		_ = events.TryRemove(id, out _);
	//	}

	//	public void AddTask(string id) =>
	//		taskRefs.AddOrUpdate(id,
	//			_ =>
	//				tcsRefs.AddOrUpdate(id,
	//				_ => new TaskCompletionSource<string>(),
	//				(_, __) => throw new InvalidOperationException()
	//				).Task,
	//			(_, __) => throw new InvalidOperationException()
	//			);

	//	public void RemoveCallback(string id)
	//	{
	//		_ = callbackRefs.TryRemove(id, out _);
	//	}
	//	#endregion

	//	#region Called from C#
	//	//internal void Add(JsObject jsObject)
	//	//{
	//	//	_ = objRefs.AddOrUpdate(jsObject.referenceId,
	//	//		(types[jsObject.GetType().Name], new WeakReference<JsObject>(jsObject)),
	//	//		(_, __) => throw new InvalidOperationException()
	//	//		);
	//	//}

	//	//internal static T? GetNullable<T>(string? id)
	//	//	where T : JsObject
	//	//{
	//	//	if (id == null) { return null; }

	//	//	var (constructor, @ref) = objRefs.GetOrAdd(id, _ => throw new ObjectDisposedException(id));
			
	//	//	if (!@ref.TryGetTarget(out var obj))
	//	//	{
	//	//		obj = constructor(id);
	//	//		@ref.SetTarget(obj);
	//	//	}

	//	//	//return (T)obj;
	//	//	return (T)typeConversionProvider.Convert(fromType: obj.GetType(), toType: typeof(T), fromValue: obj)!;
	//	//}

	//	//internal static T Get<T>(string id) where T : JsObject
	//	//	=> GetNullable<T>(id) ?? throw new NullReferenceException();

	//	internal static Task<string> GetTask(string id)
	//	{
	//		if (taskRefs.TryRemove(id, out var task))
	//		{
	//			return task;
	//		}
	//		else
	//		{
	//			throw new InvalidOperationException();
	//		}
	//	}

	//	internal static TaskCompletionSource<string> GetTaskCompletionSource(string id)
	//	{
	//		if (tcsRefs.TryRemove(id, out var tcs))
	//		{
	//			return tcs;
	//		}
	//		else
	//		{
	//			throw new InvalidOperationException();
	//		}
	//	}

	//	internal static void Update(JsObject target)
	//	{
	//		throw new NotImplementedException();

	//		//_ = objRefs.AddOrUpdate(target.referenceId,
	//		//	_ => throw new ObjectDisposedException(target.referenceId),
	//		//	(_, x) => (x.constructor, new WeakReference<JsObject>(target))
	//		//	);
	//	}

	//	internal static string AddCallback(Delegate callback)
	//	{
	//		var id = Guid.NewGuid().ToString();
	//		_ = callbackRefs.AddOrUpdate(id,
	//			_ => callback,
	//			(_, __) => throw new InvalidOperationException()
	//			);
	//		return id;
	//	}

	//	internal static Delegate GetCallback(string callbackId)
	//	{
	//		if (!callbackRefs.TryGetValue(callbackId, out var callback))
	//		{
	//			throw new InvalidOperationException();
	//		}

	//		return callback;
	//	}
	//	#endregion
	//}
}
