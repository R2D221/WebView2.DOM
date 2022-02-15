using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(abbrChildNodes))]
	public sealed class abbr : HTMLElement, PhrasingContent, addressContent
	{
		public PhrasingContentNodeList abbrChildNodes { get; } = new();
		public override NodeList childNodes => abbrChildNodes;
	}
}
