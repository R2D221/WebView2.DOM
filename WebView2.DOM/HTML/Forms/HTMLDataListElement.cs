using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLDataListElement : HTMLElement
	{
		protected internal HTMLDataListElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
