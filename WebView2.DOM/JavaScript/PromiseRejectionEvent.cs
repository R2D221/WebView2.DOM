using Microsoft.Web.WebView2.Core;
using System;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/promise_rejection_event.idl

	public class PromiseRejectionEvent : Event
	{
		protected internal PromiseRejectionEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Task promise => Get<Task>();
		[Obsolete("not tested")]
		public dynamic reason => Get<any>();
	}
}