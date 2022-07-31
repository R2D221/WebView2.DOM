using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/promise_rejection_event.idl

	public sealed class PromiseRejectionEvent : Event
	{
		private PromiseRejectionEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public Promise promise => Get<Promise>();
		[Obsolete("not tested")]
		public dynamic reason => Get<any>();
	}
}