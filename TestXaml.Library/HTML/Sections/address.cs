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
	public sealed class address : HTMLElement, FlowContent, headerContent_footerContent
	{
		public addressNodeList addressChildNodes { get; } = new();
		public override NodeList childNodes => addressChildNodes;

		[ContentWrapper(typeof(Text))]
		//[ContentWrapper(typeof(address_b_ContentWrapper))]
		[WhitespaceSignificantCollection]
		public sealed class addressNodeList : NodeList
		{
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

	//[ContentProperty(nameof(Item))]
	//public class address_b_ContentWrapper : addressContent
	//{
	//	public b Item { get; set; }

	//	public address_b_ContentWrapper(b item) => Item = item;
	//}
}
