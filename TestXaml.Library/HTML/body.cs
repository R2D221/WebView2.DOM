using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(bodyChildNodes))]
	public sealed class body : HTMLElement, head_or_body
	{
		public bodyNodeList bodyChildNodes { get; } = new();
		public override NodeList childNodes => bodyChildNodes;

		[ContentWrapper(typeof(Element))]
		[ContentWrapper(typeof(Text))]
		[WhitespaceSignificantCollection]
		public sealed class bodyNodeList : NodeList
		{
			public void Add(FlowContent node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch (node)
				{
				case FlowContent: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
