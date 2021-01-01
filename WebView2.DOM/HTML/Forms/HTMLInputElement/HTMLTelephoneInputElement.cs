using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTelephoneInputElement : HTMLInputElementWithSelectableTextBase
	{
		public HTMLTelephoneInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public HTMLDataListElement? list => Get<HTMLDataListElement?>();
	}
}
