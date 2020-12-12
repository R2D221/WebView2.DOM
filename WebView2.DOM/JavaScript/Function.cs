using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class Function : JsObject
	{
		protected internal Function(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
