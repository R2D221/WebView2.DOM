using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLPasswordInputElement : HTMLInputElementWithSelectableTextBase
	{
		protected internal HTMLPasswordInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
