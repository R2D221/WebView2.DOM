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
		public section() { sectionChildNodes = new(this); }
		public FlowContentNodeList sectionChildNodes { get; }
		public override NodeList childNodes => sectionChildNodes;
	}
}
