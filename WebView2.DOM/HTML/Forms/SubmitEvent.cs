using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/submit_event.idl

	public sealed class SubmitEvent : Event
	{
		private SubmitEvent() { }

		public HTMLElement? submitter => Get<HTMLElement?>();
	}
}