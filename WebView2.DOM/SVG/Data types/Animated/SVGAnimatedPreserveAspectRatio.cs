namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_preserve_aspect_ratio.idl

	public sealed class SVGAnimatedPreserveAspectRatio : JsObject
	{
		private SVGAnimatedPreserveAspectRatio() { }

		public SVGPreserveAspectRatio baseVal => Get<SVGPreserveAspectRatio>();
		public SVGPreserveAspectRatio animVal => Get<SVGPreserveAspectRatio>();
	}
}