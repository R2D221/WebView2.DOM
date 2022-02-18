using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The div element has no special meaning at all. It represents its children. It can be used with the class, lang, and title
	/// attributes to mark up semantics common to a group of consecutive elements. It can also be used in a dl element, wrapping
	/// groups of dt and dd elements.
	/// </summary>
	[ContentProperty(nameof(divChildNodes))]
	public sealed class div : HTMLElement, FlowContent, addressContent, header_footer_Content, dlContent, dtContent
	{
		public FlowContentNodeList divChildNodes { get; } = new();
		public override NodeList childNodes => divChildNodes;

		// The spec says that if div is a child of dl, it can only receive dt and dd elements.
		// I don't think we can model this here, tho, so we'll default to flow content for everything.
	}
}
