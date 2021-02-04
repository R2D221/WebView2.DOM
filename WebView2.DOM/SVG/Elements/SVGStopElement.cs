using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_stop_element.idl

	public class SVGStopElement : SVGElement
	{
		protected internal SVGStopElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedNumber offset => Get<SVGAnimatedNumber>();
	}
}