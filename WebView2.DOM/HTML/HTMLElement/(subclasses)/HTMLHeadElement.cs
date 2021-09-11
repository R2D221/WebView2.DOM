using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLHeadElement : HTMLElement
	{
		protected internal HTMLHeadElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
