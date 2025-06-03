using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

#if NETFRAMEWORK
using FormatterServices = System.Runtime.Serialization.FormatterServices;
#else
using FormatterServices = System.Runtime.CompilerServices.RuntimeHelpers;
#endif

namespace Refactor.WebView2.DOM.Interop;

public abstract partial class BrowsingContext
{
	private readonly static ThreadLocal<BrowsingContext> global = new();

	internal static BrowsingContext Current => global.Value ?? throw new InvalidOperationException();

	internal static JsReference GlobalObject => Current.globalObject;
}

public abstract partial class BrowsingContext : IDisposable
{
	private readonly JsDispatcher dispatcher;
	private JsReference globalObject = default!;
	private readonly BrowsingContextBridge bridge;
	private readonly CancellationTokenSource cancellation = new();

	//--------

	private readonly FrozenDictionary<string, Type> types =
		typeof(Window).Assembly
		.GetTypes()
		.Where(x => x.IsClass && typeof(JsObject).IsAssignableFrom(x))
		.ToFrozenDictionary(
			type => type.FullName!.Substring(type.Namespace!.Length + 1).Replace("+", " ") switch
			{
				"JsObject" => "Object",
				var x => x,
			},
			type => type
		);

	private readonly ConcurrentDictionary<ulong, WeakReference<JsObject>>
		idToObj = new();
	//private readonly FinalizationRegistry<JsObject, (IWebView2 webView, string referenceId)>
	//	registry = new(x =>
	//	{
	//		x.webView.BeginInvoke(() =>
	//		{
	//			_ =
	//				x.webView.GetCoreWebView2()
	//				.ExecuteScriptAsync($"WebView2DOM.FreeCSharpRef({JsonSerializer.Serialize(x.referenceId)})");
	//		});
	//	});

	//--------

	private readonly Channel<(Request, TaskCompletionSource<object?>, JsDispatcherFrame)> requests;

	protected BrowsingContext(JsDispatcher dispatcher, Action onDOMContentLoaded)
	{
		this.dispatcher = dispatcher;
		this.requests = Channel.CreateUnbounded<(Request, TaskCompletionSource<object?>, JsDispatcherFrame)>(options: new() { SingleReader = true, SingleWriter = true, AllowSynchronousContinuations = true });

		dispatcher.Enqueue(() =>
		{
			globalObject = new(this, 0);
			global.Value = this;
		});

		bridge = new(dispatcher, requests, onDOMContentLoaded, cancellation.Token);
	}

	public BrowsingContextBridge Bridge => bridge;

	private T Request<T>(Request request)
	{
		var frame = new JsDispatcherFrame();

		var taskSource = new TaskCompletionSource<object?>();
		using var cancellationRegistration = cancellation.Token.Register(() => taskSource.TrySetCanceled());

		var taskAwaiter = taskSource.Task.GetAwaiter();

		var success = requests.Writer.TryWrite((request, taskSource, frame));
		Debug.Assert(success);

		JsDispatcher.Current.PushFrame(frame);
		var response = taskAwaiter.GetResult();

		return Unpack<T>(response);
	}

	internal T Get<T>(ulong refId, string property)
	{
		var request = new Getter(refId, property);
		return Request<T>(request);
	}

	internal T Invoke<T>(ulong refId, string method, object?[] @params)
	{
		for (var i = 0; i < @params.Length; i++)
		{
			@params[i] = Pack(@params[i]);
		}

		var request = new Invoke(refId, method, @params);
		return Request<T>(request);
	}

	public void Dispose()
	{
		cancellation.Cancel();
	}

	private static object? Pack(object? value)
	{
		if (value is JsObject js)
		{
			return new PlainObjectWrapper
			{
				["#id"] = js.Id
			};
		}

		return value;
	}

	private T Unpack<T>(object? value)
	{
		if (value is null) { return (T)value!; }

		//if (TryConvert(out T converted)) { return converted; }
		if (value is T converted) { return converted; }

		if (typeof(JsObject).IsAssignableFrom(typeof(T)))
		{
			var referenceId = (ulong)Unpack<int>(ComObject.GetProperty(value, "id"));
			var referenceType = Unpack<string>(ComObject.GetProperty(value, "type"));

			return (T)Load(referenceId, referenceType, typeof(T));
		}

		return (T)value!;
	}

	private object Load(ulong referenceId, string typeName, Type requestedType)
	{
		var weakRef = idToObj.GetOrAdd(referenceId, _ => new(null!));

		if (!weakRef.TryGetTarget(out var target))
		{
			if (!types.TryGetValue(typeName, out var realType))
			{
				throw new Exception($"Type {typeName} could not be mapped.");
			}

			Type type;

			if (realType.IsAssignableFrom(requestedType))
			{
				type = requestedType;
			}
			else
			{
				type = realType;
			}

			target = (JsObject)FormatterServices.GetUninitializedObject(type);

			target.SetJsReference(new JsReference(this, referenceId));
			weakRef.SetTarget(target);
			//registry.Register(target, (BrowsingContext.Current.webView, referenceId));
		}

		return target;
	}
}