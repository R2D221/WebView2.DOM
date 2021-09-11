using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public enum TableHeaderCellScope { _, row, col, rowgroup, colgroup }

	public class HTMLTableCellElement : HTMLElement
	{
		protected internal HTMLTableCellElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public uint colSpan { get => Get<uint>(); set => Set(value); }
		public uint rowSpan { get => Get<uint>(); set => Set(value); }
		public string headers { get => Get<string>(); set => Set(value); }
		public int cellIndex => Get<int>();

		public string abbr { get => Get<string>(); set => Set(value); }
		public TableHeaderCellScope scope { get => Get<TableHeaderCellScope>(); set => Set(value); }
	}
}
