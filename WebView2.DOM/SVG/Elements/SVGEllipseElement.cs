using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_ellipse_element.idl

	public class SVGEllipseElement : SVGGeometryElement
	{
		protected internal SVGEllipseElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength cx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength cy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength rx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength ry => Get<SVGAnimatedLength>();
	}
}