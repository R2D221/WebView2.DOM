using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/submit_event.idl

	public class SubmitEvent : Event
	{
		protected internal SubmitEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public HTMLElement? submitter => Get<HTMLElement?>();
	}
}