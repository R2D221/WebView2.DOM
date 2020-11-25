using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class SVGSVGElement : SVGGraphicsElement
	{
		protected internal SVGSVGElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
