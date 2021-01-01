using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_opt_group_element.idl

	public class HTMLOptGroupElement : HTMLElement
	{
		protected internal HTMLOptGroupElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public string label { get => Get<string>(); set => Set(value); }
	}
}
