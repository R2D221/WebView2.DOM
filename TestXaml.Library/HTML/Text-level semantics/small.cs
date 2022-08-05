using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The small element represents side comments such as small print.
	/// </summary>
	[ContentProperty(nameof(smallChildNodes))]
	public sealed class small : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public small() { smallChildNodes = new(this); }
		public PhrasingContentNodeList smallChildNodes { get; }
		public override NodeList childNodes => smallChildNodes;
	}
}
