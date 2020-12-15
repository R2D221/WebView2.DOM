using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLOptionElement : HTMLElement
	{
		protected internal HTMLOptionElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
