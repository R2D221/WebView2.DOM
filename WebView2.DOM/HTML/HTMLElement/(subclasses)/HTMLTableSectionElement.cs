using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTableSectionElement : HTMLElement
	{
		protected internal HTMLTableSectionElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public HTMLCollection<HTMLTableRowElement> rows => Get<HTMLCollection<HTMLTableRowElement>>();
		public HTMLTableRowElement insertRow(int index = -1) => Method<HTMLTableRowElement>().Invoke(index);
		public void deleteRow(int index) => Method().Invoke(index);
	}
}
