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
		public FlowContentNodeList blockquoteChildNodes { get; } = new();
		public override NodeList childNodes => blockquoteChildNodes;

		public Uri? cite
		{
			get => GetAttribute() is { } s ? new Uri(s, UriKind.RelativeOrAbsolute) : null;
			set => SetAttribute(value?.ToString());
		}
	}
}
