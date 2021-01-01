using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/document_fragment.idl

	public partial class DocumentFragment : Node
	{
		protected internal DocumentFragment(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}