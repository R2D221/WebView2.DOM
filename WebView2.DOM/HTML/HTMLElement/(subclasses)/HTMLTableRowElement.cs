using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTableRowElement : HTMLElement
	{
		protected internal HTMLTableRowElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public int rowIndex => Get<int>();
		public int sectionRowIndex => Get<int>();
		public HTMLCollection<HTMLTableCellElement> cells => Get<HTMLCollection<HTMLTableCellElement>>();
		public HTMLTableCellElement insertCell(int index = -1) => Method<HTMLTableCellElement>().Invoke(index);
		public void deleteCell(int index) => Method().Invoke(index);
	}
}
