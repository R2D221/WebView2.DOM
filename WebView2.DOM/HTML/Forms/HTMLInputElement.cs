using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLInputElement : HTMLElement
	{
		protected internal HTMLInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
