using System.Windows.Markup;

namespace WebView2.Markup
{
	public abstract class HTMLHeadingElement : HTMLElement { }

	/// <summary>
	/// The elements h1-h6 represent headings for their sections.
	/// </summary>
	[ContentProperty(nameof(h1ChildNodes))]
	public sealed class h1 : HTMLHeadingElement, FlowContent, HeadingContent, headerContent_footerContent
	{
		public PhrasingContentNodeList h1ChildNodes { get; } = new();
		public override NodeList childNodes => h1ChildNodes;
	}

	/// <summary>
	/// The elements h1-h6 represent headings for their sections.
	/// </summary>
	[ContentProperty(nameof(h2ChildNodes))]
	public sealed class h2 : HTMLHeadingElement, FlowContent, HeadingContent, headerContent_footerContent
	{
		public PhrasingContentNodeList h2ChildNodes { get; } = new();
		public override NodeList childNodes => h2ChildNodes;
	}

	/// <summary>
	/// The elements h1-h6 represent headings for their sections.
	/// </summary>
	[ContentProperty(nameof(h3ChildNodes))]
	public sealed class h3 : HTMLHeadingElement, FlowContent, HeadingContent, headerContent_footerContent
	{
		public PhrasingContentNodeList h3ChildNodes { get; } = new();
		public override NodeList childNodes => h3ChildNodes;
	}

	/// <summary>
	/// The elements h1-h6 represent headings for their sections.
	/// </summary>
	[ContentProperty(nameof(h4ChildNodes))]
	public sealed class h4 : HTMLHeadingElement, FlowContent, HeadingContent, headerContent_footerContent
	{
		public PhrasingContentNodeList h4ChildNodes { get; } = new();
		public override NodeList childNodes => h4ChildNodes;
	}

	/// <summary>
	/// The elements h1-h6 represent headings for their sections.
	/// </summary>
	[ContentProperty(nameof(h5ChildNodes))]
	public sealed class h5 : HTMLHeadingElement, FlowContent, HeadingContent, headerContent_footerContent
	{
		public PhrasingContentNodeList h5ChildNodes { get; } = new();
		public override NodeList childNodes => h5ChildNodes;
	}

	/// <summary>
	/// The elements h1-h6 represent headings for their sections.
	/// </summary>
	[ContentProperty(nameof(h6ChildNodes))]
	public sealed class h6 : HTMLHeadingElement, FlowContent, HeadingContent, headerContent_footerContent
	{
		public PhrasingContentNodeList h6ChildNodes { get; } = new();
		public override NodeList childNodes => h6ChildNodes;
	}
}
