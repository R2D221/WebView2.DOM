namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_boolean.idl

	public sealed class SVGAnimatedBoolean : JsObject
	{
		private SVGAnimatedBoolean() { }

		public bool baseVal { get => Get<bool>(); set => Set(value); }
		public bool animVal => Get<bool>();
	}
}