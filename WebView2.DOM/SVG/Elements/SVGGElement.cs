using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_g_element.idl

	public class SVGGElement : SVGGraphicsElement
	{
		protected internal SVGGElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}