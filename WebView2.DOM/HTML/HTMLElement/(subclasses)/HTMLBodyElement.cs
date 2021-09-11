using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public partial class HTMLBodyElement : HTMLElement
	{
		protected internal HTMLBodyElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
