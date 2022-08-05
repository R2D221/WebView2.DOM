using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The nav element represents a section of a page that links to other pages or to parts within the page: a section with navigation links.
	/// </summary>
	[ContentProperty(nameof(navChildNodes))]
	public sealed class nav : HTMLElement, FlowContent, SectioningContent, header_footer_Content
	{
		public nav() { navChildNodes = new(this); }
		public FlowContentNodeList navChildNodes { get; }
		public override NodeList childNodes => navChildNodes;
	}
}
