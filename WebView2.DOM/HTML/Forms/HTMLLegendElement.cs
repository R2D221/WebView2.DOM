namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_legend_element.idl

	public sealed class HTMLLegendElement : HTMLElement
	{
		private HTMLLegendElement() { }

		public HTMLFormElement? form => Get<HTMLFormElement?>();
	}
}
