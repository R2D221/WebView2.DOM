using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/pop_state_event.idl

	public sealed class PopStateEvent : Event
	{
		private PopStateEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public dynamic state => Get<any>();
	}
}