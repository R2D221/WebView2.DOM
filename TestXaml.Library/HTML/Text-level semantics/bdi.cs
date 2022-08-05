using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The bdi element represents a span of text that is to be isolated from its surroundings for the
	/// purposes of bidirectional text formatting.
	/// </summary>
	[ContentProperty(nameof(bdiChildNodes))]
	public sealed class bdi : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public bdi() { bdiChildNodes = new(this); }
		public PhrasingContentNodeList bdiChildNodes { get; }
		public override NodeList childNodes => bdiChildNodes;
	}
}
