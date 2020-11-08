namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/animation_event.idl

	public class AnimationEvent : Event
	{
		public string animationName => Get<string>();
		public double elapsedTime => Get<double>();
		public string pseudoElement => Get<string>();
	}
}
