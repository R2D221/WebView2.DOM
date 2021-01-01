using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLResetInputElement : HTMLInputElement
	{
		public HTMLResetInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
