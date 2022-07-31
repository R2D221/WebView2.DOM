using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/page_transition_event.idl

	public sealed class PageTransitionEvent : Event
	{
		private PageTransitionEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public bool persisted => Get<bool>();
	}
}