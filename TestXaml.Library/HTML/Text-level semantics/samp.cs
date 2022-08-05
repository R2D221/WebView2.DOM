using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The samp element represents sample or quoted output from another program or computing system.
	/// </summary>
	[ContentProperty(nameof(sampChildNodes))]
	public sealed class samp : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public samp() { sampChildNodes = new(this); }
		public PhrasingContentNodeList sampChildNodes { get; }
		public override NodeList childNodes => sampChildNodes;
	}
}
