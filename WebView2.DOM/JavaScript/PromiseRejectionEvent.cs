using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/promise_rejection_event.idl

	public sealed class PromiseRejectionEvent : Event
	{
		private PromiseRejectionEvent() { }

		public Promise promise => Get<Promise>();
		[Obsolete("not tested")]
		public dynamic reason => Get<any>();
	}
}