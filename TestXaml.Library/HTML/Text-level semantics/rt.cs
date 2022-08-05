using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The rt element marks the ruby text component of a ruby annotation. When it is the child of a
	/// ruby element, it doesn't represent anything itself, but the ruby element uses it as part of
	/// determining what it represents.
	/// </summary>
	[ContentProperty(nameof(rtChildNodes))]
	public sealed class rt : HTMLElement
	{
		public rt() { rtChildNodes = new(this); }
		public PhrasingContentNodeList rtChildNodes { get; }
		public override NodeList childNodes => rtChildNodes;
	}
}
