using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLSelectElement : HTMLElement
	{
		protected internal HTMLSelectElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
