namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_ellipse_element.idl

	public sealed class SVGEllipseElement : SVGGeometryElement
	{
		private SVGEllipseElement() { }

		public SVGAnimatedLength cx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength cy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength rx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength ry => Get<SVGAnimatedLength>();
	}
}