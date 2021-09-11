using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTemplateElement : HTMLElement
	{
		protected internal HTMLTemplateElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public DocumentFragment content => Get<DocumentFragment>();
		// readonly attribute ShadowRoot? shadowRoot;
	}
}
