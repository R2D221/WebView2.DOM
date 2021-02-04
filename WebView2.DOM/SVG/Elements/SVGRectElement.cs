using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_rect_element.idl

	public class SVGRectElement : SVGGeometryElement
	{
		protected internal SVGRectElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedLength rx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength ry => Get<SVGAnimatedLength>();
	}
}