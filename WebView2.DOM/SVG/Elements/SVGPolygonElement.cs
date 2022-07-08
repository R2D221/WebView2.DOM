namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_polygon_element.idl

	public sealed class SVGPolygonElement : SVGGeometryElement
	{
		private SVGPolygonElement() { }

		public SVGPointList points => Get<SVGPointList>();
		public SVGPointList animatedPoints => Get<SVGPointList>();
	}
}