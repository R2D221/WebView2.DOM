using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The nav element represents a section of a page that links to other pages or to parts within the page: a section with navigation links.
	/// </summary>
	[ContentProperty(nameof(navChildNodes))]
	public sealed class nav : HTMLElement, FlowContent, SectioningContent, headerContent_footerContent
	{
		public FlowContentNodeList navChildNodes { get; } = new();
		public override NodeList childNodes => navChildNodes;
	}
}
