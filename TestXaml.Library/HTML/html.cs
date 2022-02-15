using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(htmlChildNodes))]
	public sealed class html : HTMLElement
	{
		public htmlNodeList htmlChildNodes { get; } = new();
		public override NodeList childNodes => htmlChildNodes;

		public sealed class htmlNodeList : NodeList
		{
			public void Add(head_or_body node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch ((Count, node))
				{
				case (_, Text t) when string.IsNullOrWhiteSpace(t.data): return false;
				case (0, head): return true;
				case (1, body): return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
