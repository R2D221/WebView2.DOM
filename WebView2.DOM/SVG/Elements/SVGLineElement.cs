namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_line_element.idl

	public sealed class SVGLineElement : SVGGeometryElement
	{
		private SVGLineElement() { }

		public SVGAnimatedLength x1 => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y1 => Get<SVGAnimatedLength>();
		public SVGAnimatedLength x2 => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y2 => Get<SVGAnimatedLength>();
	}
}