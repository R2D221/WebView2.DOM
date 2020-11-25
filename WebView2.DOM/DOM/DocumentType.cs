using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/document_type.idl

	public partial class DocumentType : JsObject
	{
		protected internal DocumentType(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string name => Get<string>();
		public string publicId => Get<string>();
		public string systemId => Get<string>();
	}
}