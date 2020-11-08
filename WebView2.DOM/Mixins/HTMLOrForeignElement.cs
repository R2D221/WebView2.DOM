namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_or_foreign_element.idl

	public struct FocusOptions
	{
		public bool preventScroll { get; set; }
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
