using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xpath_ns_resolver.idl

	public class XPathNSResolver : JsObject
	{
		protected internal XPathNSResolver(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string? lookupNamespaceURI(string prefix = "undefined") =>
			Method<string?>().Invoke(prefix);
	}
}
