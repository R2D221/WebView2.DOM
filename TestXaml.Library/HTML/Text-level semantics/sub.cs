using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The sub element represents a subscript.
	/// </summary>
	[ContentProperty(nameof(subChildNodes))]
	public sealed class sub : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList subChildNodes { get; } = new();
		public override NodeList childNodes => subChildNodes;
	}
}
