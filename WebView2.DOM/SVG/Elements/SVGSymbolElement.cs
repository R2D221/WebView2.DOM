using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_symbol_element.idl

	public partial class SVGSymbolElement : SVGElement
	{
		protected internal SVGSymbolElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}

	public partial class SVGSymbolElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => Get<SVGAnimatedRect>();

		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => Get<SVGAnimatedPreserveAspectRatio>();
	}
}