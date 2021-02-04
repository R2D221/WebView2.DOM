using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_metadata_element.idl

	public class SVGMetadataElement : SVGElement
	{
		protected internal SVGMetadataElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}