using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLLabelElement : HTMLElement
	{
		protected internal HTMLLabelElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
