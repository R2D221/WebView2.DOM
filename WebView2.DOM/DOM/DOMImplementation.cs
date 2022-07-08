namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/dom_implementation.idl

	public sealed class DOMImplementation : JsObject
	{
		private DOMImplementation() { }

		public DocumentType createDocumentType(string qualifiedName, string publicId, string systemId) =>
			Method<DocumentType>().Invoke(qualifiedName, publicId, systemId);
		public XMLDocument createDocument(string? namespaceURI, string qualifiedName, DocumentType? doctype = null) =>
			Method<XMLDocument>().Invoke(namespaceURI, qualifiedName, doctype);
		public Document createHTMLDocument() => Method<Document>().Invoke();
		public Document createHTMLDocument(string title) => Method<Document>().Invoke(title);
	}
}