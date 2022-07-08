namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_string.idl

	public sealed class SVGAnimatedString : JsObject
	{
		private SVGAnimatedString() { }

		public string baseVal { get => Get<string>(); set => Set(value); }
		public string animVal => Get<string>();
	}
}