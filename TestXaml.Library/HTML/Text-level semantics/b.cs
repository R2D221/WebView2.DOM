using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The b element represents a span of text to which attention is being drawn for utilitarian
	/// purposes without conveying any extra importance and with no implication of an alternate voice
	/// or mood, such as key words in a document abstract, product names in a review, actionable words
	/// in interactive text-driven software, or an article lede.
	/// </summary>
	[ContentProperty(nameof(bChildNodes))]
	public sealed class b : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList bChildNodes { get; } = new();
		public override NodeList childNodes => bChildNodes;
	}
}
