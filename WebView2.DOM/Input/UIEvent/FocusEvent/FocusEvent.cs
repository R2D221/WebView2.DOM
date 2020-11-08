namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/focus_event.idl

	public class FocusEvent : UIEvent
	{
		public EventTarget? relatedTarget => Get<EventTarget?>();
	}
}