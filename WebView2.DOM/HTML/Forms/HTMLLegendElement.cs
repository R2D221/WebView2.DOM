using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_legend_element.idl

	public class HTMLLegendElement : HTMLElement
	{
		protected internal HTMLLegendElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public HTMLFormElement? form => Get<HTMLFormElement?>();
	}
}
