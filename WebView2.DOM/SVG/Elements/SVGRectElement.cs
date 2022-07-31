namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_rect_element.idl

	public sealed class SVGRectElement : SVGGeometryElement
	{
		private SVGRectElement() { }

		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength rx => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength ry => GetCached<SVGAnimatedLength>();
	}
}