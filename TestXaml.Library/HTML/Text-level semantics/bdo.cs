using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The bdo element represents explicit text directionality formatting control for its children.
	/// It allows authors to override the Unicode bidirectional algorithm by explicitly specifying a
	/// direction override.
	/// </summary>
	[ContentProperty(nameof(bdoChildNodes))]
	public sealed class bdo : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public bdo() { bdoChildNodes = new(this); }
		public PhrasingContentNodeList bdoChildNodes { get; }
		public override NodeList childNodes => bdoChildNodes;
	}
}
