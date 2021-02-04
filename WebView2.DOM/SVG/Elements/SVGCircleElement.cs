using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_circle_element.idl
	
	public class SVGCircleElement : SVGGeometryElement
	{
		protected internal SVGCircleElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength cx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength cy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength r => Get<SVGAnimatedLength>();
	}
}