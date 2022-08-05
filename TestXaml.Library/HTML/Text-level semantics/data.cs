using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The data element represents its contents, along with a machine-readable form of those contents
	/// in the value attribute.
	/// </summary>
	[ContentProperty(nameof(dataChildNodes))]
	public sealed class data : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public data() { dataChildNodes = new(this); }
		public PhrasingContentNodeList dataChildNodes { get; }
		public override NodeList childNodes => dataChildNodes;

		/// <summary>
		/// The value attribute must be present. Its value must be a representation of the element's
		/// contents in a machine-readable format.
		/// </summary>
		public string? value
		{
			get => GetAttribute();
			set => SetAttribute(value);
		}
	}
}
