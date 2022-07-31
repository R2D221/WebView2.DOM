namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_circle_element.idl

	public sealed class SVGCircleElement : SVGGeometryElement
	{
		private SVGCircleElement() { }

		public SVGAnimatedLength cx => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength cy => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength r => GetCached<SVGAnimatedLength>();
	}
}