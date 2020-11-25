using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/media_query_list_event.idl

	public class MediaQueryListEvent : Event
	{
		protected internal MediaQueryListEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string media => Get<string>();
		public bool matches => Get<bool>();
	}
}
