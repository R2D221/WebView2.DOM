using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLLegendElement : HTMLElement
	{
		protected internal HTMLLegendElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
