using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLHtmlElement : HTMLElement
	{
		protected internal HTMLHtmlElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
