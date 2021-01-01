using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_data_list_element.idl

	public class HTMLDataListElement : HTMLElement
	{
		protected internal HTMLDataListElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public HTMLCollection<HTMLOptionElement> options =>
			Get<HTMLCollection<HTMLOptionElement>>();
	}
}
