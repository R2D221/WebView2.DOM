using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLButtonElement : HTMLElement
	{
		protected internal HTMLButtonElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
