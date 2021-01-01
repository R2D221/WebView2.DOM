using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_option_element.idl

	public class HTMLOptionElement : HTMLElement
	{
		protected internal HTMLOptionElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public string label { get => Get<string>(); set => Set(value); }
		public bool defaultSelected { get => Get<bool>(); set => Set(value); }
		public bool selected { get => Get<bool>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }

		public string text { get => Get<string>(); set => Set(value); }
		public int index => Get<int>();
	}
}
