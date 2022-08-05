using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The pre element represents a block of preformatted text, in which structure is represented by typographic conventions rather
	/// than by elements.
	/// </summary>
	[ContentProperty(nameof(preChildNodes))]
	public sealed class pre : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		public pre() { preChildNodes = new(this); }
		public PhrasingContentNodeList preChildNodes { get; }
		public override NodeList childNodes => preChildNodes;
	}
}
