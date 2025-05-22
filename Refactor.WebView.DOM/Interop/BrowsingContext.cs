using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
	private readonly JsThread thread;
	private JsReference globalObject = default!;
	private readonly BrowsingContextBridge bridge;
	private readonly CancellationTokenSource cancellation = new();

	//--------

	private readonly JsonSerializerOptions jsonOptions;

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

	private readonly Channel<(Request, TaskCompletionSource<string?>)> requests;

	protected BrowsingContext(JsThread thread, Action onDOMContentLoaded)
	{
		this.thread = thread;
		this.requests = Channel.CreateUnbounded<(Request, TaskCompletionSource<string?>)>(options: new() { SingleReader = true, SingleWriter = true });

		thread.Enqueue(() =>
		{
			globalObject = new(this, 0);
			global.Value = this;
		});

		jsonOptions = new(options: new() { Converters = { new JsObjectJsonConverter(this) } });
		bridge = new(thread, requests, onDOMContentLoaded, jsonOptions, cancellation.Token);
	}

	public BrowsingContextBridge Bridge => bridge;

	private T Request<T>(Request request)
	{
		var taskSource = new TaskCompletionSource<string?>();
		using var cancellationRegistration = cancellation.Token.Register(() => taskSource.TrySetCanceled());

		var success = requests.Writer.TryWrite((request, taskSource));
		Debug.Assert(success);
		var response = taskSource.Task.GetAwaiter().GetResult();

		if (response is null) { return (T)(object)ValueTuple.Create(); }
		return JsonSerializer.Deserialize<T>(response, jsonOptions)!;
	}

	internal T Get<T>(ulong refId, string property)
	{
		var request = new Getter(refId, property);
		return Request<T>(request);
	}

	internal T Invoke<T>(ulong refId, string method, ReadOnlySpan<object?> @params)
	{
		var request = new Invoke(refId, method, [.. @params]);
		return Request<T>(request);
	}

	public void Dispose()
	{
		cancellation.Cancel();
	}

	sealed class JsObjectJsonConverter(BrowsingContext browsingContext) : JsonConverter<JsObject>
	{
		public override bool CanConvert(Type typeToConvert) => typeof(JsObject).IsAssignableFrom(typeToConvert);

		public override JsObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				return null;
			}

			if (true
			&& reader.TokenType == JsonTokenType.StartObject
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.PropertyName
			&& reader.GetString() == "id"
			&& reader.Read()
			&& reader.GetUInt64() is ulong referenceId
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.PropertyName
			&& reader.GetString() == "type"
			&& reader.Read()
			&& reader.GetString() is string referenceType
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.EndObject
			)
			{
				return browsingContext.Load(referenceId, referenceType, typeToConvert);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public override void Write(Utf8JsonWriter writer, JsObject value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			writer.WriteStartObject();
			writer.WriteNumber("#id", value.Id);
			writer.WriteEndObject();
		}
	}

	private JsObject? Load(ulong referenceId, string typeName, Type requestedType)
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