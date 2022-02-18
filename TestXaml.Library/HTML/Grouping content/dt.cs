using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	public interface dtContent { }

	/// <summary>
	/// The dt element represents the term, or name, part of a term-description group in a description list (dl element).
	/// </summary>
	[ContentProperty(nameof(dtChildNodes))]
	public sealed class dt : HTMLElement, dlContent
	{
		public dtNodeList dtChildNodes { get; } = new();
		public override NodeList childNodes => dtChildNodes;

		[ContentWrapper(typeof(Text))]
		[WhitespaceSignificantCollection]
		public sealed class dtNodeList : NodeList
		{
			public void Add(dtContent node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
#warning The spec says *descendants*, not just children.

				switch (node)
				{
				case HeadingContent: throw new System.Exception();
				case SectioningContent: throw new System.Exception();
				case header: throw new System.Exception();
				case footer: throw new System.Exception();

				case FlowContent: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
