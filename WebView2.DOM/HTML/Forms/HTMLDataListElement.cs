namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_data_list_element.idl

	public sealed class HTMLDataListElement : HTMLElement
	{
		private HTMLDataListElement() { }

		public HTMLCollection<HTMLOptionElement> options =>
			Get<HTMLCollection<HTMLOptionElement>>();
	}
}
