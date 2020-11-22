using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	public sealed class References
	{
		private static readonly ConcurrentDictionary<string, TaskCompletionSource<string>> tcsRefs =
			new ConcurrentDictionary<string, TaskCompletionSource<string>>();

		private static readonly ConcurrentDictionary<string, Task<string>> taskRefs =
			new ConcurrentDictionary<string, Task<string>>();

		private static readonly ConcurrentDictionary<string, JsObject> objRefs =
			new ConcurrentDictionary<string, JsObject>();

		private static readonly ConcurrentDictionary<string, Delegate> callbackRefs =
			new ConcurrentDictionary<string, Delegate>();

		private readonly Dictionary<string, Func<string, JsObject>> types;
		private readonly CoreWebView2 coreWebView;

		internal References(CoreWebView2 coreWebView)
		{
			this.coreWebView = coreWebView;
			types =
				typeof(Window).Assembly
				.GetTypes()
				.Where(x => x.IsClass && typeof(JsObject).IsAssignableFrom(x))
				.ToDictionary<Type, string, Func<string, JsObject>>(
					type => type.Name,
					type => (id) =>
					{
						var obj = (JsObject)Activator.CreateInstance(type)!;
						obj.coreWebView = coreWebView;
						obj.referenceId = id;
						return obj;
					}
				);
		}

		#region Called from JavaScript
		public void Add(string id, string type)
		{
			objRefs.AddOrUpdate(id,
				_ =>
				{
					if (types.TryGetValue(type, out var constructor))
					{
						return constructor(id);
					}
					else if (type.EndsWith("Iterator"))
					{
						return new Iterator { coreWebView = coreWebView, referenceId = id };
					}
					else
					{
						throw new InvalidOperationException($"JavaScript type {type} not found in C#");
					}
				},
				(_, __) => throw new InvalidOperationException()
				);
		}

		public void Remove(string id)
		{
			objRefs.TryRemove(id, out _);
		}

		public void AddTask(string id)
		{
			taskRefs.AddOrUpdate(id,
				_ =>
					tcsRefs.AddOrUpdate(id,
					_ => new TaskCompletionSource<string>(),
					(_, __) => throw new InvalidOperationException()
					).Task,
				(_, __) => throw new InvalidOperationException()
				);
		}

		public void RemoveCallback(string id)
		{
			callbackRefs.TryRemove(id, out _);
		}
		#endregion

		#region Called from C#
		internal void Add(JsObject jsObject)
		{
			objRefs.AddOrUpdate(jsObject.referenceId,
				jsObject,
				(_, __) => throw new InvalidOperationException()
				);
		}

		internal static T? GetNullable<T>(string? id)
			where T : JsObject
		{
			if (id == null) { return null; }

			return (T)TypeConvert.Convert
			(
				value: objRefs.GetOrAdd(id, _ => throw new ObjectDisposedException(id)),
				toType: typeof(T)
			);
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

		internal static void Swap(JsObject source, JsObject target)
		{
			target.referenceId = source.referenceId;
			target.coreWebView = source.coreWebView;

			source.referenceId = null!;
			source.coreWebView = null!;

			objRefs.AddOrUpdate(target.referenceId,
				_ => throw new ObjectDisposedException(target.referenceId),
				(_, __) => target
				);
		}

		internal static string AddCallback(Delegate callback)
		{
			var id = System.Guid.NewGuid().ToString();
			callbackRefs.AddOrUpdate(id,
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
