using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLPreElement : HTMLElement
	{
		protected internal HTMLPreElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
