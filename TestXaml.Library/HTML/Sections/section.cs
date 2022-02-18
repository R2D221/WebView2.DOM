using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The section element represents a generic section of a document or application. A section, in this context, is a thematic grouping
	/// of content, typically with a heading.
	/// </summary>
	[ContentProperty(nameof(sectionChildNodes))]
	public sealed class section : HTMLElement, FlowContent, SectioningContent, header_footer_Content
	{
		public FlowContentNodeList sectionChildNodes { get; } = new();
		public override NodeList childNodes => sectionChildNodes;
	}
}
