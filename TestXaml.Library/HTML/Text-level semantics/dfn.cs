using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The dfn element represents the defining instance of a term. The paragraph, description list group, or section that is the nearest
	/// ancestor of the dfn element must also contain the definition(s) for the term given by the dfn element.
	/// </summary>
	[ContentProperty(nameof(dfnChildNodes))]
	public sealed class dfn : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public dfn() { dfnChildNodes = new(this); }
		public PhrasingContentNodeList dfnChildNodes { get; }
		public override NodeList childNodes => dfnChildNodes;

		#warning Content model: Phrasing content, but there must be no dfn element descendants.
	}
}
