using SmartAnalyzers.CSharpExtensions.Annotations;
using System;
using System.Collections.Generic;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/message_port.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/post_message_options.idl

	public record PostMessageOptions
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public IReadOnlyList<Transferable> transfer
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= Array.Empty<Transferable>();

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public bool includeUserActivation
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= false;
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
