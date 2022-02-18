using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The ul element represents a list of items, where the order of the items is not important — that is, where changing the order would
	/// not materially change the meaning of the document.
	/// </summary>
	[ContentProperty(nameof(ulChildNodes))]
	public sealed class ul : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		public ol_ul_NodeList ulChildNodes { get; } = new();
		public override NodeList childNodes => ulChildNodes;
	}
}
