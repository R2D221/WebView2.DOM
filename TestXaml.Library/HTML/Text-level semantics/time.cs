using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The time element represents its contents, along with a machine-readable form of those contents
	/// in the datetime attribute. The kind of content is limited to various kinds of dates, times,
	/// time-zone offsets, and durations.
	/// </summary>
	[ContentProperty(nameof(timeChildNodes))]
	public sealed class time : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public time() { timeChildNodes = new(this); }
		public PhrasingContentNodeList timeChildNodes { get; }
		public override NodeList childNodes => timeChildNodes;

		/// <summary>
		/// The datetime attribute may be present. If present, its value must be a representation of
		/// the element's contents in a machine-readable format.
		/// </summary>
		public string? datetime
		{
#warning Parse this datetime with microdata
			get => GetAttribute();
			set => SetAttribute(value);
		}
	}
}
