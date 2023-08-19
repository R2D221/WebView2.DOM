using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_or_foreign_element.idl

	[JsonConverter(typeof(Converter))]
	public record FocusOptions : JsDictionary
	{
		private class Converter : Converter<FocusOptions> { }

		public required bool preventScroll
		{
			get => GetRequired<bool>();
			init => Set(value);
		}
	}

	public interface HTMLOrForeignElement
	{
		DOMStringMap dataset { get; }
		string nonce { get; set; }

		bool autofocus { get; set; }
		int tabIndex { get; set; }
		void focus();
		void focus(FocusOptions options);
		void blur();
	}
}
