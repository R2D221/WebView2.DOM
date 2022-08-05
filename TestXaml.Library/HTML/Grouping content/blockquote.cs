using System;
using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The blockquote element represents a section that is quoted from another source.
	/// </summary>
	[ContentProperty(nameof(blockquoteChildNodes))]
	public sealed class blockquote : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		public blockquote() { blockquoteChildNodes = new(this); }
		public FlowContentNodeList blockquoteChildNodes { get; }
		public override NodeList childNodes => blockquoteChildNodes;

		/// <summary>
		/// Content inside a blockquote must be quoted from another source, whose address, if it has one, may be cited in the cite attribute.
		/// </summary>
		public Uri? cite
		{
			get => GetAttribute() is { } s ? new Uri(s, UriKind.RelativeOrAbsolute) : null;
			set => SetAttribute(value?.ToString());
		}
	}
}
