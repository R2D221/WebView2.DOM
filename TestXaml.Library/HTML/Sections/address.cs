using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	public interface addressContent { }

	/// <summary>
	/// The address element represents the contact information for its nearest article or body element ancestor. If that is the body
	/// element, then the contact information applies to the document as a whole.
	/// </summary>
	[ContentProperty(nameof(addressChildNodes))]
	public sealed class address : HTMLElement, FlowContent, header_footer_Content, dtContent
	{
		public address() { addressChildNodes = new(this); }
		public addressNodeList addressChildNodes { get; }
		public override NodeList childNodes => addressChildNodes;

		[ContentWrapper(typeof(Text))]
		[WhitespaceSignificantCollection]
		public sealed class addressNodeList : NodeList
		{
			public addressNodeList(Node owner) : base(owner) { }

			public void Add(addressContent node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
#warning The spec says *descendants*, not just children.

				switch (node)
				{
				case HeadingContent: throw new System.Exception();
				case SectioningContent: throw new System.Exception();
				case header: throw new System.Exception();
				case footer: throw new System.Exception();
				case address: throw new System.Exception();

				case FlowContent: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
