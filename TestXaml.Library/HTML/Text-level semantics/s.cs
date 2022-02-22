using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The s element represents contents that are no longer accurate or no longer relevant.
	/// </summary>
	[ContentProperty(nameof(sChildNodes))]
	public sealed class s : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList sChildNodes { get; } = new();
		public override NodeList childNodes => sChildNodes;
	}
}
