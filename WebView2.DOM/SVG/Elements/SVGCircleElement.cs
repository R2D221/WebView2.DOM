namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_circle_element.idl

	public sealed class SVGCircleElement : SVGGeometryElement
	{
		private SVGCircleElement() { }

		public SVGAnimatedLength cx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength cy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength r => Get<SVGAnimatedLength>();
	}
}