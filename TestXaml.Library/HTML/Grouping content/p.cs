using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The p element represents a paragraph.
	/// </summary>
	[ContentProperty(nameof(pChildNodes))]
	public sealed class p : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		public p() { pChildNodes = new(this); }
		public PhrasingContentNodeList pChildNodes { get; }
		public override NodeList childNodes => pChildNodes;
	}
}
