using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/focus_event.idl

	public class FocusEvent : UIEvent
	{
		protected internal FocusEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public EventTarget? relatedTarget => Get<EventTarget?>();
	}
}