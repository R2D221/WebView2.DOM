using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_polyline_element.idl

	public class SVGPolylineElement : SVGGeometryElement
	{
		protected internal SVGPolylineElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGPointList points => Get<SVGPointList>();
		public SVGPointList animatedPoints => Get<SVGPointList>();
	}
}