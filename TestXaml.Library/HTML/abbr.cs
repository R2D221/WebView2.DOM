using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(abbrChildNodes))]
	public sealed class abbr : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList abbrChildNodes { get; } = new();
		public override NodeList childNodes => abbrChildNodes;
	}
}
