using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLDivElement : HTMLElement
	{
		protected internal HTMLDivElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
