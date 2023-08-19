using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/message_port.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/messaging/post_message_options.idl

	[JsonConverter(typeof(Converter))]
	public record PostMessageOptions : JsDictionary
	{
		private class Converter : Converter<PostMessageOptions> { }

		public IReadOnlyList<Transferable> transfer
		{
			get => Get<IReadOnlyList<Transferable>>(defaultValue: Array.Empty<Transferable>());
			init => Set(value);
		}

		public bool includeUserActivation
		{
			get => Get<bool>(defaultValue: false);
			init => Set(value);
		}
	}

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
