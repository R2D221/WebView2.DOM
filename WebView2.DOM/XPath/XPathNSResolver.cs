namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xpath_ns_resolver.idl

	public sealed class XPathNSResolver : JsObject
	{
		private XPathNSResolver() { }

		public string? lookupNamespaceURI(string prefix = "undefined") =>
			Method<string?>().Invoke(prefix);
	}
}
