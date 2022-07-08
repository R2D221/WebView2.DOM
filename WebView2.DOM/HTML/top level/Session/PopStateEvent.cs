namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/pop_state_event.idl

	public sealed class PopStateEvent : Event
	{
		private PopStateEvent() { }

		public dynamic state => Get<any>();
	}
}