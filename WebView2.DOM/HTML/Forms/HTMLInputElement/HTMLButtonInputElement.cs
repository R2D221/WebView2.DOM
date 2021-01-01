using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLButtonInputElement : HTMLInputElement
	{
		public HTMLButtonInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
