using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLFieldSetElement : HTMLElement
	{
		protected internal HTMLFieldSetElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
