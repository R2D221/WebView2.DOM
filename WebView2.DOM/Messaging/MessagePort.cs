using System;
using System.Collections.Generic;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/message_port.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/post_message_options.idl

	public class PostMessageOptions
	{
		public IReadOnlyList<Transferable> transfer { get; set; } = Array.Empty<Transferable>();
		public bool includeUserActivation { get; set; }
	}

	[Obsolete("not tested")]
	public partial class MessagePort : EventTarget
	{
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
