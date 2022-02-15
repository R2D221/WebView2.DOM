using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The footer element represents a footer for its nearest ancestor sectioning content or sectioning root element. A footer
	/// typically contains information about its section such as who wrote it, links to related documents, copyright data, and
	/// the like.
	/// </summary>
	[ContentProperty(nameof(footerChildNodes))]
	public sealed class footer : HTMLElement, FlowContent
	{
		public header_footer_NodeList footerChildNodes { get; } = new();
		public override NodeList childNodes => footerChildNodes;
	}
}
