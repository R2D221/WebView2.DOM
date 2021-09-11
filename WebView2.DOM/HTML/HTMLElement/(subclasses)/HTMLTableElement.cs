using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTableElement : HTMLElement
	{
		protected internal HTMLTableElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public HTMLTableCaptionElement? caption { get => Get<HTMLTableCaptionElement?>(); set => Set(value); }
		public HTMLTableCaptionElement createCaption() => Method<HTMLTableCaptionElement>().Invoke();
		public void deleteCaption() => Method().Invoke();
		public HTMLTableSectionElement? tHead { get => Get<HTMLTableSectionElement?>(); set => Set(value); }
		public HTMLTableSectionElement createTHead() => Method<HTMLTableSectionElement>().Invoke();
		public void deleteTHead() => Method().Invoke();
		public HTMLTableSectionElement? tFoot { get => Get<HTMLTableSectionElement?>(); set => Set(value); }
		public HTMLTableSectionElement createTFoot() => Method<HTMLTableSectionElement>().Invoke();
		public void deleteTFoot() => Method().Invoke();
		public HTMLCollection<HTMLTableSectionElement> tBodies => Get<HTMLCollection<HTMLTableSectionElement>>();
		public HTMLTableSectionElement createTBody() => Method<HTMLTableSectionElement>().Invoke();
		public HTMLCollection<HTMLTableRowElement> rows => Get<HTMLCollection<HTMLTableRowElement>>();
		public HTMLTableRowElement insertRow(int index = -1) => Method<HTMLTableRowElement>().Invoke(index);
		public void deleteRow(int index) => Method().Invoke(index);
		// attribute boolean sortable;
		// void stopSorting();
	}
}
