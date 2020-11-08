using System;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/promise_rejection_event.idl

	public class PromiseRejectionEvent : Event
	{
		public Task promise => Get<Task>();
		[Obsolete("not tested")]
		public dynamic reason => Get<any>();
	}
}