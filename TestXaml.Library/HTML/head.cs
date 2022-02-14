using System.Collections;
using System.Linq;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(headChildNodes))]
	public sealed class head : HTMLElement, head_or_body
	{
		public headNodeList headChildNodes { get; } = new();
		public override NodeList childNodes => headChildNodes;

		[ContentWrapper(typeof(@base))]
		[ContentWrapper(typeof(link))]
		[ContentWrapper(typeof(meta))]
		[ContentWrapper(typeof(noscript))]
		[ContentWrapper(typeof(script))]
		[ContentWrapper(typeof(style))]
		[ContentWrapper(typeof(template))]
		[ContentWrapper(typeof(title))]
		public sealed class headNodeList : NodeList
		{
			public void Add(MetadataContent node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch (node)
				{

				case Text t when string.IsNullOrWhiteSpace(t.data): return false;

				case WebView2.Markup.title:
				{
					if (this.Cast<Node>().Any(x => x is title))
					{
						throw new System.Exception("Can't add more than one <title> to <head>");
					}
					else
					{
						return true;
					}
				}

				case @base:
				{
					if (this.Cast<Node>().Any(x => x is @base))
					{
						throw new System.Exception("Can't add more than one <base> to <head>");
					}
					else
					{
						return true;
					}
				}

				case MetadataContent: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
