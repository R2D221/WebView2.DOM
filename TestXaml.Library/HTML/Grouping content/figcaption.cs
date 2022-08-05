using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The figcaption element represents a caption or legend for the rest of the contents of the figcaption element's parent figure
	/// element, if any.
	/// </summary>
	[ContentProperty(nameof(figcaptionChildNodes))]
	public sealed class figcaption : HTMLElement
	{
		public figcaption() { figcaptionChildNodes = new(this); }
		public FlowContentNodeList figcaptionChildNodes { get; }
		public override NodeList childNodes => figcaptionChildNodes;
	}
}
