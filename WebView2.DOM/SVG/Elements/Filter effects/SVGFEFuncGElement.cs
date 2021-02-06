using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_func_g_element.idl

	public class SVGFEFuncGElement : SVGComponentTransferFunctionElement
	{
		protected internal SVGFEFuncGElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}