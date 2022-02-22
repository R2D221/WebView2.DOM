using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The code element represents a fragment of computer code. This could be an XML element name,
	/// a filename, a computer program, or any other string that a computer would recognize.
	/// </summary>
	[ContentProperty(nameof(codeChildNodes))]
	public sealed class code : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList codeChildNodes { get; } = new();
		public override NodeList childNodes => codeChildNodes;
	}
}
