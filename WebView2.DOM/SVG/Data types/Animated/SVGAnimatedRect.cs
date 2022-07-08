namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_rect.idl

	public sealed class SVGAnimatedRect : JsObject
	{
		private SVGAnimatedRect() { }

		public SVGRect baseVal => Get<SVGRect>();
		public SVGRect animVal => Get<SVGRect>();
	}
}