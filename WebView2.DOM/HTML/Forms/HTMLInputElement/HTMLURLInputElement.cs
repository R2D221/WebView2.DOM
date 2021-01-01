using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLURLInputElement : HTMLInputElementWithSelectableTextBase
	{
		public HTMLURLInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public HTMLDataListElement? list => Get<HTMLDataListElement?>();
	}
}
