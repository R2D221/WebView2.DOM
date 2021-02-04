using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_geometry_element.idl

	public class SVGGeometryElement : SVGGraphicsElement
	{
		protected internal SVGGeometryElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedNumber pathLength => _pathLength ??= Get<SVGAnimatedNumber>();
		private SVGAnimatedNumber? _pathLength;

		public bool isPointInFill(SVGPoint point) => Method<bool>().Invoke(point);
		public bool isPointInStroke(SVGPoint point) => Method<bool>().Invoke(point);
		public float getTotalLength() => Method<float>().Invoke();
		public SVGPoint getPointAtLength(float distance) =>
			Method<SVGPoint>().Invoke(distance);
	}
}