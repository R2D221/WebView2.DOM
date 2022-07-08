namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_integer.idl
	public sealed class SVGAnimatedInteger : JsObject
	{
		private SVGAnimatedInteger() { }

		public int baseVal { get => Get<int>(); set => Set(value); }
		public int animVal => Get<int>();
	}
}