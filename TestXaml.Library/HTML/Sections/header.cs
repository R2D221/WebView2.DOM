using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The header element represents a group of introductory or navigational aids.
	/// </summary>
	[ContentProperty(nameof(headerChildNodes))]
	public sealed class header : HTMLElement, FlowContent
	{
		public header_footer_NodeList headerChildNodes { get; } = new();
		public override NodeList childNodes => headerChildNodes;
	}
}
