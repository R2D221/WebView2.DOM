using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/dom_implementation.idl

	public class DOMImplementation : JsObject
	{
		protected internal DOMImplementation(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public DocumentType createDocumentType(string qualifiedName, string publicId, string systemId) =>
			Method<DocumentType>().Invoke(qualifiedName, publicId, systemId);
		public XMLDocument createDocument(string? namespaceURI, string qualifiedName, DocumentType? doctype = null) =>
			Method<XMLDocument>().Invoke(namespaceURI, qualifiedName, doctype);
		public Document createHTMLDocument() => Method<Document>().Invoke();
		public Document createHTMLDocument(string title) => Method<Document>().Invoke(title);
	}
}