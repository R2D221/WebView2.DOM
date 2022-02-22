using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The i element represents a span of text in an alternate voice or mood, or otherwise offset
	/// from the normal prose in a manner indicating a different quality of text, such as a taxonomic
	/// designation, a technical term, an idiomatic phrase from another language, transliteration, a
	/// thought, or a ship name in Western texts.
	/// </summary>
	[ContentProperty(nameof(iChildNodes))]
	public sealed class i : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList iChildNodes { get; } = new();
		public override NodeList childNodes => iChildNodes;
	}
}
