using System;
using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	public interface dlContent { }

	/// <summary>
	/// The dl element represents an association list consisting of zero or more name-value groups (a description list). A name-value group
	/// consists of one or more names (dt elements, possibly as children of a div element child) followed by one or more values (dd elements,
	/// possibly as children of a div element child), ignoring any nodes other than dt and dd element children, and dt and dd elements that
	/// are children of div element children. Within a single dl element, there should not be more than one dt element for each name.
	/// </summary>
	[ContentProperty(nameof(dlChildNodes))]
	public sealed class dl : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		public dl() { dlChildNodes = new(this); }
		public dlNodeList dlChildNodes { get; }
		public override NodeList childNodes => dlChildNodes;

		public sealed class dlNodeList : NodeList
		{
			public dlNodeList(Node owner) : base(owner) { }

			public void Add(dlContent node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch (node)
				{
				case dt: return true;

				case dd:
				{
					if (this.Count == 0) { throw new Exception(); }

					return true;
				}

				case div: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}
}
