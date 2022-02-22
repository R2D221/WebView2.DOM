using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The kbd element represents user input (typically keyboard input, although it may also be used
	/// to represent other input, such as voice commands).
	/// </summary>
	[ContentProperty(nameof(kbdChildNodes))]
	public sealed class kbd : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList kbdChildNodes { get; } = new();
		public override NodeList childNodes => kbdChildNodes;
	}
}
