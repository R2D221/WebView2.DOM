namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_ellipse_element.idl

	public sealed class SVGEllipseElement : SVGGeometryElement
	{
		private SVGEllipseElement() { }

		public SVGAnimatedLength cx => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength cy => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength rx => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength ry => GetCached<SVGAnimatedLength>();
	}
}