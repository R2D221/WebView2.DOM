using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The sup element represents a superscript.
	/// </summary>
	[ContentProperty(nameof(supChildNodes))]
	public sealed class sup : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList supChildNodes { get; } = new();
		public override NodeList childNodes => supChildNodes;
	}
}
