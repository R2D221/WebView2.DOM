using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The sub element represents a subscript.
	/// </summary>
	[ContentProperty(nameof(subChildNodes))]
	public sealed class sub : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public sub() { subChildNodes = new(this); }
		public PhrasingContentNodeList subChildNodes { get; }
		public override NodeList childNodes => subChildNodes;
	}
}
