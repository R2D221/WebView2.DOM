namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_number.idl

	public sealed class SVGAnimatedNumber : JsObject
	{
		private SVGAnimatedNumber() { }

		public float baseVal { get => Get<float>(); set => Set(value); }
		public float animVal => Get<float>();
	}
}