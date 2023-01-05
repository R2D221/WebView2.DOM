using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/message_port.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/post_message_options.idl

	public record PostMessageOptions
	{
		[JsonIgnore]
		public IReadOnlyList<Transferable> transfer
		{
			get => _transfer ?? Array.Empty<Transferable>();
			init => _transfer = value;
		}

		[JsonIgnore]
		public bool includeUserActivation
		{
			get => _includeUserActivation ?? false;
			init => _includeUserActivation = value;
		}

		[JsonPropertyName(nameof(transfer))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IReadOnlyList<Transferable>? _transfer { get; init; }

		[JsonPropertyName(nameof(includeUserActivation))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool? _includeUserActivation { get; init; }
	}

	[Obsolete("not tested")]
	public sealed partial class MessagePort : EventTarget
	{
		private MessagePort() { }

		public void postMessage(object? message) => Method().Invoke(message);
		public void postMessage(object? message, IReadOnlyList<Transferable> transfer) => Method().Invoke(message, transfer);
		public void postMessage(object? message, PostMessageOptions options) => Method().Invoke(message, options);
		public void start() => Method().Invoke();
		public void close() => Method().Invoke();

		// event handlers
		public event EventHandler<MessageEvent/*	*/> onmessage/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<MessageEvent/*	*/> onmessageerror/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
	}
}
