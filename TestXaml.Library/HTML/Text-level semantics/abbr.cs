using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The abbr element represents an abbreviation or acronym, optionally with its expansion. The
	/// title attribute may be used to provide an expansion of the abbreviation. The attribute, if
	/// specified, must contain an expansion of the abbreviation, and nothing else.
	/// </summary>
	[ContentProperty(nameof(abbrChildNodes))]
	public sealed class abbr : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList abbrChildNodes { get; } = new();
		public override NodeList childNodes => abbrChildNodes;
	}
}
