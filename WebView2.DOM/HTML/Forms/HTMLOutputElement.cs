using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLOutputElement : HTMLElement
	{
		protected internal HTMLOutputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
