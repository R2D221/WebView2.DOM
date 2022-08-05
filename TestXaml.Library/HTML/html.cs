using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(htmlChildNodes))]
	public sealed class html : HTMLElement
	{
		public html() { htmlChildNodes = new(this); }
		public htmlNodeList htmlChildNodes { get; }
		public override NodeList childNodes => htmlChildNodes;

		public sealed class htmlNodeList : NodeList
		{
			public htmlNodeList(Node owner) : base(owner) { }

			public void Add(head_or_body node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch (node)
				{
				case head: return true;
				case body: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
