using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The mark element represents a run of text in one document marked or highlighted for reference
	/// purposes, due to its relevance in another context. When used in a quotation or other block of
	/// text referred to from the prose, it indicates a highlight that was not originally present but
	/// which has been added to bring the reader's attention to a part of the text that might not have
	/// been considered important by the original author when the block was originally written, but
	/// which is now under previously unexpected scrutiny. When used in the main prose of a document,
	/// it indicates a part of the document that has been highlighted due to its likely relevance to
	/// the user's current activity.
	/// </summary>
	[ContentProperty(nameof(markChildNodes))]
	public sealed class mark : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public mark() { markChildNodes = new(this); }
		public PhrasingContentNodeList markChildNodes { get; }
		public override NodeList childNodes => markChildNodes;
	}
}
