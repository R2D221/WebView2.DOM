using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The dd element represents the description, definition, or value, part of a term-description group in a description list (dl element).
	/// </summary>
	[ContentProperty(nameof(ddChildNodes))]
	public sealed class dd : HTMLElement, dlContent
	{
		public dd() { ddChildNodes = new(this); }
		public FlowContentNodeList ddChildNodes { get; }
		public override NodeList childNodes => ddChildNodes;
	}
}
