using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The ruby element allows one or more spans of phrasing content to be marked with ruby
	/// annotations. Ruby annotations are short runs of text presented alongside base text, primarily
	/// used in East Asian typography as a guide for pronunciation or to include other annotations.
	/// In Japanese, this form of typography is also known as furigana.
	/// </summary>
	[ContentProperty(nameof(rubyChildNodes))]
	public sealed class ruby : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
//#error Test this
		public ruby() { rubyChildNodes = new(this); }
		public rubyNodeList rubyChildNodes { get; }
		public override NodeList childNodes => rubyChildNodes;

#warning ruby content model:
		/*
		The content model of ruby elements consists of one or more of the following sequences:

		1. One or the other of the following:
			• Phrasing content, but with no ruby elements and with no ruby element descendants
			• A single ruby element that itself has no ruby element descendants
		2. One or the other of the following:
			• One or more rt elements
			• An rp element followed by one or more rt elements, each of which is itself followed by an rp element
		*/

		[ContentWrapper(typeof(Text))]
		[ContentWrapper(typeof(rtWrapper))]
		[ContentWrapper(typeof(rpWrapper))]
		[WhitespaceSignificantCollection]
		public sealed class rubyNodeList : NodeList
		{
			public rubyNodeList(Node owner) : base(owner) { }

			public void Add(PhrasingContent node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch (node)
				{
				case rt: return true;
				case rp: return true;
				case PhrasingContent: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}

	[ContentProperty(nameof(Item))]
	public class rtWrapper : PhrasingContent
	{
		public rt Item { get; set; }

		public rtWrapper(rt item) => Item = item;
	}

	[ContentProperty(nameof(Item))]
	public class rpWrapper : PhrasingContent
	{
		public rp Item { get; set; }

		public rpWrapper(rp item) => Item = item;
	}
}
