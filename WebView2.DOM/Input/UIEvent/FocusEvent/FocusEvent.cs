using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/focus_event.idl

	public sealed class FocusEvent : UIEvent
	{
		private FocusEvent() { }

		public EventTarget? relatedTarget => Get<EventTarget?>();
	}
}