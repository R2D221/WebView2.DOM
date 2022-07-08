namespace WebView2.DOM
{
	public sealed class HTMLTableSectionElement : HTMLElement
	{
		private HTMLTableSectionElement() { }

		public HTMLCollection<HTMLTableRowElement> rows => Get<HTMLCollection<HTMLTableRowElement>>();
		public HTMLTableRowElement insertRow(int index = -1) => Method<HTMLTableRowElement>().Invoke(index);
		public void deleteRow(int index) => Method().Invoke(index);
	}
}
