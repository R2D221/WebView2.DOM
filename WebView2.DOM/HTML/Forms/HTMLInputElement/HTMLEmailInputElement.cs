using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLEmailInputElement : HTMLInputElementWithTextBase
	{
		protected internal HTMLEmailInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public HTMLDataListElement? list => Get<HTMLDataListElement?>();
	}
}
