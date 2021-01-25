using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLCanvasElement : HTMLElement
	{
		protected internal HTMLCanvasElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
