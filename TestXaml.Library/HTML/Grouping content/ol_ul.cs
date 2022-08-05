using System.Collections;

namespace WebView2.Markup
{
	public sealed class ol_ul_NodeList : NodeList
	{
		public ol_ul_NodeList(Node owner) : base(owner) { }

		public void Add(li node) => _ = ((IList)this).Add(node);

		protected override bool Validate(Node node)
		{
			switch (node)
			{
			case li: return true;

			default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
			}
		}
	}
}
