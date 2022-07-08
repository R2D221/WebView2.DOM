namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_polyline_element.idl

	public sealed class SVGPolylineElement : SVGGeometryElement
	{
		private SVGPolylineElement() { }

		public SVGPointList points => Get<SVGPointList>();
		public SVGPointList animatedPoints => Get<SVGPointList>();
	}
}