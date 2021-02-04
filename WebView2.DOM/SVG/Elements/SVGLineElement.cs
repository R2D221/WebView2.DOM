using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_line_element.idl
	
	public class SVGLineElement : SVGGeometryElement
	{
		protected internal SVGLineElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength x1 => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y1 => Get<SVGAnimatedLength>();
		public SVGAnimatedLength x2 => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y2 => Get<SVGAnimatedLength>();
	}
}