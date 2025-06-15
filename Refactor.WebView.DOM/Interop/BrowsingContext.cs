using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
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

		bridge = new(this, requests, onDOMContentLoaded, cancellation.Token);
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

		return (T)Unpack(response, typeof(T))!;
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

	internal void ReturnVoid()
	{
		var request = new ReturnVoid();
		var success = requests.Writer.TryWrite((request, null!, null!));
		Debug.Assert(success);
	}

	internal void Return(object? value)
	{
		var request = new Return(Pack(value));
		var success = requests.Writer.TryWrite((request, null!, null!));
		Debug.Assert(success);
	}

	internal void Throw(Exception exception)
	{
		var request = new Throw(new(exception));
		var success = requests.Writer.TryWrite((request, null!, null!));
		Debug.Assert(success);
	}

	public void Dispose()
	{
		cancellation.Cancel();
	}

	private object? Pack(object? value)
	{
		if (value is JsObject js)
		{
			//return new PlainObjectWrapper
			//{
			//	["#id"] = js.Id
			//};

			return new IdWrapper { Id = js.Id };
		}

		if (value is Delegate @delegate)
		{
			return new CallbackWrapper(this, @delegate);
		}

		return value;
	}

	[return: NotNullIfNotNull(nameof(value))]
	internal object? Unpack(object? value, Type requestedType)
	{
		if (value is null) { return null; }

		//if (TryConvert(out T converted)) { return converted; }
		if (value.GetType() == requestedType) { return value; }

		if (typeof(JsObject).IsAssignableFrom(requestedType))
		{
			var referenceId = ComObject.GetProperty(value, "id") switch
			{
				int i => (ulong)i,
				double d => (ulong)d,
				_ => throw new Exception(),
			};

			var referenceType = ComObject.GetProperty(value, "type") switch
			{
				string s => s,
				_ => throw new Exception(),
			};

			return Load(referenceId, referenceType, requestedType);
		}

		return value;
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

	internal void Call(Delegate @delegate, object[] args)
	{
		dispatcher.Enqueue(() =>
		{
			try
			{
				var @params = @delegate.Method.GetParameters();

				var length = Math.Max(args.Length, @params.Length);

				for (var i = 0; i < length; i++)
				{
					args[i] = Unpack(args[i], @params[i].ParameterType);
				}

				var result = @delegate.DynamicInvoke(args);

				if (@delegate.Method.ReturnType == typeof(void))
				{
					ReturnVoid();
				}
				else
				{
					Return(result);
				}
			}
			catch (TargetInvocationException ex)
			{
				Throw(ex.InnerException!);
			}
			catch (Exception ex)
			{
				Throw(ex);
			}
		});
	}
}