using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The body element represents the contents of the document.
	/// </summary>
	[ContentProperty(nameof(bodyChildNodes))]
	public sealed class body : HTMLElement, head_or_body
	{
		public FlowContentNodeList bodyChildNodes { get; } = new();
		public override NodeList childNodes => bodyChildNodes;
	}
}
