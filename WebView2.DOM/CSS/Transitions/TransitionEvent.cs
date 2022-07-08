namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/transition_event.idl

	public sealed class TransitionEvent : Event
	{
		private TransitionEvent() { }

		public string propertyName => Get<string>();
		public double elapsedTime => Get<double>();
		public string pseudoElement => Get<string>();
	}
}
