using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_label_element.idl

	public class HTMLLabelElement : HTMLElement
	{
		protected internal HTMLLabelElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public string htmlFor { get => Get<string>(); set => Set(value); }
		public ILabelableElement? control => Get<ILabelableElement>();
	}
}
