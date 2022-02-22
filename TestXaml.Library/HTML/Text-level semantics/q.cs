using System;
using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The q element represents some phrasing content quoted from another source.
	/// </summary>
	[ContentProperty(nameof(qChildNodes))]
	public sealed class q : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public PhrasingContentNodeList qChildNodes { get; } = new();
		public override NodeList childNodes => qChildNodes;

		/// <summary>
		/// Content inside a q element must be quoted from another source, whose address, if it has one, may be cited in the cite attribute.
		/// The source may be fictional, as when quoting characters in a novel or screenplay.
		/// </summary>
		public Uri? cite
		{
			get => GetAttribute() is { } s ? new Uri(s, UriKind.RelativeOrAbsolute) : null;
			set => SetAttribute(value?.ToString());
		}
	}
}
