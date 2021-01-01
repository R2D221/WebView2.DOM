using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/radio_node_list.idl

	public class RadioNodeList : NodeList<HTMLElement>
	{
		protected internal RadioNodeList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string value { get => Get<string>(); set => Set(value); }
	}
}