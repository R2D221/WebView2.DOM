using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	public interface headerContent_footerContent { }

	[ContentWrapper(typeof(Text))]
	[WhitespaceSignificantCollection]
	public sealed class header_footer_NodeList : NodeList
	{
		public void Add(headerContent_footerContent node) => _ = ((IList)this).Add(node);

		protected override bool Validate(Node node)
		{
#warning The spec says *descendants*, not just children.

			switch (node)
			{
			case header: throw new System.Exception();
			case footer: throw new System.Exception();

			case FlowContent: return true;

			default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
			}
		}
	}
}
