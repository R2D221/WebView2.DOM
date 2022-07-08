namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_length.idl

	public sealed class SVGAnimatedLength : JsObject
	{
		private SVGAnimatedLength() { }

		public SVGLength baseVal => Get<SVGLength>();
		public SVGLength animVal => Get<SVGLength>();
	}
}