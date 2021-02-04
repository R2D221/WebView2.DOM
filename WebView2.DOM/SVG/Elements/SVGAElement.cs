using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_a_element.idl

	public partial class SVGAElement : SVGGraphicsElement
	{
		protected internal SVGAElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedString target => Get<SVGAnimatedString>();
	}
}