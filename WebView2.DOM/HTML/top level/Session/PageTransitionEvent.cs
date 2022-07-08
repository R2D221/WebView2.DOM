namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/page_transition_event.idl

	public sealed class PageTransitionEvent : Event
	{
		private PageTransitionEvent() { }

		public bool persisted => Get<bool>();
	}
}