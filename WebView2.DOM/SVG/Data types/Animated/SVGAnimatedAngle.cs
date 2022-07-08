namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_angle.idl

	public sealed class SVGAnimatedAngle : JsObject
	{
		private SVGAnimatedAngle() { }

		public SVGAngle baseVal => Get<SVGAngle>();
		public SVGAngle animVal => Get<SVGAngle>();
	}
}