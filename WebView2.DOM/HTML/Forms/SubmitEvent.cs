namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/submit_event.idl

	public class SubmitEvent : Event
	{
		public HTMLElement? submitter => Get<HTMLElement?>();
	}
}