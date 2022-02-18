using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The aside element represents a section of a page that consists of content that is tangentially related to the content around
	/// the aside element, and which could be considered separate from that content. Such sections are often represented as sidebars
	/// in printed typography.
	/// </summary>
	[ContentProperty(nameof(asideChildNodes))]
	public sealed class aside : HTMLElement, FlowContent, SectioningContent, header_footer_Content
	{
		public FlowContentNodeList asideChildNodes { get; } = new();
		public override NodeList childNodes => asideChildNodes;
	}
}
