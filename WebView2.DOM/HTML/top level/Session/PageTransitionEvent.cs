using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/page_transition_event.idl

	public class PageTransitionEvent : Event
	{
		protected internal PageTransitionEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool persisted => Get<bool>();
	}
}