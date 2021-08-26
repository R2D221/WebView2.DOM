using deniszykov.TypeConversion;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	public sealed class References
	{
		private static readonly TypeConversionProvider typeConversionProvider = new();

		private static readonly ConcurrentDictionary<string, TaskCompletionSource<string>>
			tcsRefs = new();
		
		private static readonly ConcurrentDictionary<string, Task<string>>
			taskRefs = new();
		
		private static readonly ConcurrentDictionary<string, (Func<string, JsObject> constructor, WeakReference<JsObject> @ref)>
			objRefs = new();
		
		private static readonly ConcurrentDictionary<string, Delegate>
			callbackRefs = new();

		internal static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, Delegate?>>
			events = new();

		private readonly Dictionary<string, Func<string, JsObject>> types;

		internal References(CoreWebView2 coreWebView)
		{
			var t1 =
				typeof(Window).Assembly
				.GetTypes()
				.Where(x => x.IsClass && typeof(JsObject).IsAssignableFrom(x))
				.ToDictionary(
					type => type.Name switch
					{
						"JsObject" => "Object",
						_ => type.Name,
					},
					type => (Func<string, JsObject>)
					(
						(id) =>
							(JsObject)Activator.CreateInstance(
							type: type,
							bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance,
							binder: null,
							args: new object?[] { coreWebView, id },
							culture: null)!
					)
				);

			var t2 = new Dictionary<string, Func<string, JsObject>>
			{
				["hidden"/*	*/] = (id) => new HTMLHiddenInputElement/*	*/(coreWebView, id),
				["text"/*	*/] = (id) => new HTMLTextInputElement/*	*/(coreWebView, id),
				["search"/*	*/] = (id) => new HTMLSearchInputElement/*	*/(coreWebView, id),
				["tel"/*	*/] = (id) => new HTMLTelephoneInputElement/*	*/(coreWebView, id),
				["url"/*	*/] = (id) => new HTMLURLInputElement/*	*/(coreWebView, id),
				["email"/*	*/] = (id) => new HTMLEmailInputElement/*	*/(coreWebView, id),
				["password"/*	*/] = (id) => new HTMLPasswordInputElement/*	*/(coreWebView, id),
				["date"/*	*/] = (id) => new HTMLDateInputElement/*	*/(coreWebView, id),
				["month"/*	*/] = (id) => new HTMLMonthInputElement/*	*/(coreWebView, id),
				["week"/*	*/] = (id) => new HTMLWeekInputElement/*	*/(coreWebView, id),
				["time"/*	*/] = (id) => new HTMLTimeInputElement/*	*/(coreWebView, id),
				["datetime-local"/*	*/] = (id) => new HTMLLocalDateTimeInputElement/*	*/(coreWebView, id),
				["number"/*	*/] = (id) => new HTMLNumberInputElement/*	*/(coreWebView, id),
				["range"/*	*/] = (id) => new HTMLRangeInputElement/*	*/(coreWebView, id),
				["color"/*	*/] = (id) => new HTMLColorInputElement/*	*/(coreWebView, id),
				["checkbox"/*	*/] = (id) => new HTMLCheckboxInputElement/*	*/(coreWebView, id),
				["radio"/*	*/] = (id) => new HTMLRadioButtonInputElement/*	*/(coreWebView, id),
				["file"/*	*/] = (id) => new HTMLFileUploadInputElement/*	*/(coreWebView, id),
				["submit"/*	*/] = (id) => new HTMLSubmitInputElement/*	*/(coreWebView, id),
				["image"/*	*/] = (id) => new HTMLImageInputElement/*	*/(coreWebView, id),
				["reset"/*	*/] = (id) => new HTMLResetInputElement/*	*/(coreWebView, id),
				["button"/*	*/] = (id) => new HTMLButtonInputElement/*	*/(coreWebView, id),
			};

			types = new Dictionary<string, Func<string, JsObject>>(t1.Concat(t2));
		}

		#region Called from JavaScript
		public void Add(string id, string type) =>
			objRefs.AddOrUpdate(id,
				_ => types.TryGetValue(type, out var constructor)
					? (constructor, new WeakReference<JsObject>(constructor(id)))
					: throw new InvalidOperationException($"JavaScript type {type} not found in C#"),
				(_, __) => throw new InvalidOperationException()
				);

		public void AddHTMLInputElement(string id, string type) =>
			objRefs.AddOrUpdate(id,
				_ => types.TryGetValue(type, out var constructor)
					? (constructor, new WeakReference<JsObject>(constructor(id)))
					: throw new InvalidOperationException($"HTMLInputElement of type {type} not found in C#"),
				(_, __) => throw new InvalidOperationException()
				);

		public void Remove(string id)
		{
			_ = objRefs.TryRemove(id, out _);
			_ = events.TryRemove(id, out _);
		}

		public void AddTask(string id) =>
			taskRefs.AddOrUpdate(id,
				_ =>
					tcsRefs.AddOrUpdate(id,
					_ => new TaskCompletionSource<string>(),
					(_, __) => throw new InvalidOperationException()
					).Task,
				(_, __) => throw new InvalidOperationException()
				);

		public void RemoveCallback(string id)
		{
			_ = callbackRefs.TryRemove(id, out _);
		}
		#endregion

		#region Called from C#
		internal void Add(JsObject jsObject)
		{
			_ = objRefs.AddOrUpdate(jsObject.referenceId,
				(types[jsObject.GetType().Name], new WeakReference<JsObject>(jsObject)),
				(_, __) => throw new InvalidOperationException()
				);
		}

		internal static T? GetNullable<T>(string? id)
			where T : JsObject
		{
			if (id == null) { return null; }

			var (constructor, @ref) = objRefs.GetOrAdd(id, _ => throw new ObjectDisposedException(id));
			
			if (!@ref.TryGetTarget(out var obj))
			{
				obj = constructor(id);
				@ref.SetTarget(obj);
			}

			//return (T)obj;
			return (T)typeConversionProvider.Convert(fromType: obj.GetType(), toType: typeof(T), fromValue: obj)!;
		}

		internal static T Get<T>(string id) where T : JsObject
			=> GetNullable<T>(id) ?? throw new NullReferenceException();

		internal static Task<string> GetTask(string id)
		{
			if (taskRefs.TryRemove(id, out var task))
			{
				return task;
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		internal static TaskCompletionSource<string> GetTaskCompletionSource(string id)
		{
			if (tcsRefs.TryRemove(id, out var tcs))
			{
				return tcs;
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		internal static void Update(JsObject target)
		{
			_ = objRefs.AddOrUpdate(target.referenceId,
				_ => throw new ObjectDisposedException(target.referenceId),
				(_, x) => (x.constructor, new WeakReference<JsObject>(target))
				);
		}

		internal static string AddCallback(Delegate callback)
		{
			var id = Guid.NewGuid().ToString();
			_ = callbackRefs.AddOrUpdate(id,
				_ => callback,
				(_, __) => throw new InvalidOperationException()
				);
			return id;
		}

		internal static Delegate GetCallback(string callbackId)
		{
			if (!callbackRefs.TryGetValue(callbackId, out var callback))
			{
				throw new InvalidOperationException();
			}

			return callback;
		}
		#endregion
	}
}
