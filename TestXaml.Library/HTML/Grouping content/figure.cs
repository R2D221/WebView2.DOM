﻿using System.Collections;
using System.Linq;
using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The figure element represents some flow content, optionally with a caption, that is self-contained (like a complete sentence) and is
	/// typically referenced as a single unit from the main flow of the document.
	/// </summary>
	[ContentProperty(nameof(figureChildNodes))]
	public sealed class figure : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		public figure() { figureChildNodes = new(this); }
		public figureNodeList figureChildNodes { get; }
		public override NodeList childNodes => figureChildNodes;

		[ContentWrapper(typeof(Text))]
		[ContentWrapper(typeof(figcaptionWrapper))]
		[WhitespaceSignificantCollection]
		public sealed class figureNodeList : NodeList
		{
			public figureNodeList(Node owner) : base(owner) { }

			public void Add(FlowContent node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch (node)
				{
				case figcaption:
				{
					if (this.Cast<Node>().Any(x => x is figcaption)) { throw new System.Exception(); }

					return true;
				}
				case FlowContent: return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}

	[ContentProperty(nameof(Item))]
	public class figcaptionWrapper : FlowContent
	{
		public figcaption Item { get; set; }

		public figcaptionWrapper(figcaption item) => Item = item;
	}
}