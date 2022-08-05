using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The u element represents a span of text with an unarticulated, though explicitly rendered,
	/// non-textual annotation, such as labeling the text as being a proper name in Chinese text
	/// (a Chinese proper name mark), or labeling the text as being misspelt.
	/// </summary>
	[ContentProperty(nameof(uChildNodes))]
	public sealed class u : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public u() { uChildNodes = new(this); }
		public PhrasingContentNodeList uChildNodes { get; }
		public override NodeList childNodes => uChildNodes;
	}
}
