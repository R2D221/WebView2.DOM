using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/media_query_list_event.idl

	public sealed class MediaQueryListEvent : Event
	{
		private MediaQueryListEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public string media => Get<string>();
		public bool matches => Get<bool>();
	}
}
