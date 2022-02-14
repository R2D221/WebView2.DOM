using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(headChildNodes))]
	public sealed class head : HTMLElement, head_or_body
	{
		public DefaultNodeList headChildNodes { get; } = new();
		public override NodeList childNodes => headChildNodes;
	}
}
