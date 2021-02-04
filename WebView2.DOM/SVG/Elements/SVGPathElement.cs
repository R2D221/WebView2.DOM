using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	//https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_path_element.idl

	public class SVGPathElement : SVGGeometryElement
	{
		protected internal SVGPathElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}