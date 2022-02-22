using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The var element represents a variable. This could be an actual variable in a mathematical
	/// expression or programming context, an identifier representing a constant, a symbol identifying
	/// a physical quantity, a function parameter, or just be a term used as a placeholder in prose.
	/// </summary>
	[ContentProperty(nameof(varChildNodes))]
	public sealed class var : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList varChildNodes { get; } = new();
		public override NodeList childNodes => varChildNodes;
	}
}
