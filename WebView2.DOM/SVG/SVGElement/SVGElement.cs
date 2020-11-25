using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class SVGElement : Element
	{
		protected internal SVGElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}