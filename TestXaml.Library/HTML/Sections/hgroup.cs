using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(hgroupChildNodes))]
	public sealed class hgroup : HTMLElement, FlowContent, HeadingContent, header_footer_Content
	{
		public hgroup() { hgroupChildNodes = new(this); }
		public hgroupNodeList hgroupChildNodes { get; }
		public override NodeList childNodes => hgroupChildNodes;

		public class hgroupNodeList : NodeList
		{
			// The spec says the content model for hgroup can be “optionally intermixed with script-supporting elements”,
			// but I don't see the point of adding them.

			public hgroupNodeList(Node owner) : base(owner) { }

			public void Add(HTMLHeadingElement node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch (node)
				{
				case HTMLHeadingElement: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
