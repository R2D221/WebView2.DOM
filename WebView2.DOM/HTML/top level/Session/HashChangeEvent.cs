using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/hash_change_event.idl

	public sealed class HashChangeEvent : Event
	{
		private HashChangeEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public string oldURL => Get<string>();
		public string newURL => Get<string>();
	}
}