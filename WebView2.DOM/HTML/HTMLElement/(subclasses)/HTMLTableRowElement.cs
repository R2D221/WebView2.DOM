namespace WebView2.DOM
{
	public sealed class HTMLTableRowElement : HTMLElement
	{
		private HTMLTableRowElement() { }

		public int rowIndex => Get<int>();
		public int sectionRowIndex => Get<int>();
		public HTMLCollection<HTMLTableCellElement> cells => Get<HTMLCollection<HTMLTableCellElement>>();
		public HTMLTableCellElement insertCell(int index = -1) => Method<HTMLTableCellElement>().Invoke(index);
		public void deleteCell(int index) => Method().Invoke(index);
	}
}
