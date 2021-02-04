using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_radial_gradient_element.idl

	public class SVGRadialGradientElement : SVGGradientElement
	{
		protected internal SVGRadialGradientElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength cx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength cy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength r => Get<SVGAnimatedLength>();
		public SVGAnimatedLength fx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength fy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength fr => Get<SVGAnimatedLength>();
	}
}