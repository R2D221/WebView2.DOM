using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The article element represents a complete, or self-contained, composition in a document, page, application, or site and that is,
	/// in principle, independently distributable or reusable, e.g. in syndication. This could be a forum post, a magazine or newspaper
	/// article, a blog entry, a user-submitted comment, an interactive widget or gadget, or any other independent item of content.
	/// </summary>
	[ContentProperty(nameof(articleChildNodes))]
	public sealed class article : HTMLElement, FlowContent, SectioningContent, headerContent_footerContent
	{
		public FlowContentNodeList articleChildNodes { get; } = new();
		public override NodeList childNodes => articleChildNodes;
	}
}
