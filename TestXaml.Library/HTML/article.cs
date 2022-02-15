using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	//[ContentProperty(nameof(articleChildNodes))]
	public sealed class article : HTMLElement, FlowContent, SectioningContent
	{
		//public articleNodeList articleChildNodes { get; } = new();
		//public override NodeList childNodes => articleChildNodes;

		//[WhitespaceSignificantCollection]
		//public sealed class articleNodeList : NodeList
		//{
		//	public void Add(FlowContent node) => _ = ((IList)this).Add(node);

		//	protected override bool Validate(Node node)
		//	{
		//		switch (node)
		//		{

		//		case FlowContent: return true;

		//		default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
		//		}
		//	}
		//}
	}
}
