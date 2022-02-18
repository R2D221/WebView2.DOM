using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The dd element represents the description, definition, or value, part of a term-description group in a description list (dl element).
	/// </summary>
	[ContentProperty(nameof(ddChildNodes))]
	public sealed class dd : HTMLElement, dlContent
	{
		public FlowContentNodeList ddChildNodes { get; } = new();
		public override NodeList childNodes => ddChildNodes;
	}
}
