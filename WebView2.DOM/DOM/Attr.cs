using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/attr.idl

	public class Attr : Node
	{
		protected internal Attr(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string? namespaceURI => Get<string?>();
		public string? prefix => Get<string?>();
		public string localName => Get<string>();
		public string name => Get<string>();
		public string value
		{
			get => Get<string>();
			set => Set(value);
		}
		public Element? ownerElement => Get<Element?>();
	}
}
