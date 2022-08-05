using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The em element represents stress emphasis of its contents.
	/// </summary>
	[ContentProperty(nameof(emChildNodes))]
	public sealed class em : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public em() { emChildNodes = new(this); }
		public PhrasingContentNodeList emChildNodes { get; }
		public override NodeList childNodes => emChildNodes;
	}
}
