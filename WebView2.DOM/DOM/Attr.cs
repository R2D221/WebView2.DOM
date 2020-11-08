namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/attr.idl

	public class Attr : Node
	{
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
