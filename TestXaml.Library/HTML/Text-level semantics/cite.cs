using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The cite element represents the title of a work (e.g. a book, a paper, an essay, a poem, a score, a song, a script, a film, a TV show,
	/// a game, a sculpture, a painting, a theatre production, a play, an opera, a musical, an exhibition, a legal case report, a computer
	/// program, etc.). This can be a work that is being quoted or referenced in detail (i.e., a citation), or it can just be a work that is
	/// mentioned in passing.
	/// </summary>
	[ContentProperty(nameof(citeChildNodes))]
	public sealed class cite : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList citeChildNodes { get; } = new();
		public override NodeList childNodes => citeChildNodes;
	}
}
