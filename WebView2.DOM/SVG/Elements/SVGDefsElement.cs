using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_defs_element.idl

	public class SVGDefsElement : SVGGraphicsElement
	{
		protected internal SVGDefsElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}