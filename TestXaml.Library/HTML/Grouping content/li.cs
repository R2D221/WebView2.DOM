using System.Text.Json;
using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The li element represents a list item. If its parent element is an ol, ul, or menu element, then the element is an item of the
	/// parent element's list, as defined for those elements. Otherwise, the list item has no defined list-related relationship to any
	/// other li element.
	/// </summary>
	[ContentProperty(nameof(liChildNodes))]
	public sealed class li : HTMLElement
	{
		public li() { liChildNodes = new(this); }
		public FlowContentNodeList liChildNodes { get; }
		public override NodeList childNodes => liChildNodes;

		/// <summary>
		/// The value attribute, if present, must be a valid integer. It is used to determine the ordinal value of the list item, when
		/// the li's list owner is an ol element.
		/// </summary>
		public int? value
		{
			get => GetAttribute() is { } s ? JsonSerializer.Deserialize<int>(s) : null;
			set => SetAttribute(value is { } i ? JsonSerializer.Serialize(i) : null);
		}
	}
}
