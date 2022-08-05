using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The span element doesn't mean anything on its own, but can be useful when used together with
	/// the global attributes, e.g. class, lang, or dir. It represents its children.
	/// </summary>
	[ContentProperty(nameof(spanChildNodes))]
	public sealed class span : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public span() { spanChildNodes = new(this); }
		public PhrasingContentNodeList spanChildNodes { get; }
		public override NodeList childNodes => spanChildNodes;
	}
}
