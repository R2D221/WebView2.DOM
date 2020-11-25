using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/hash_change_event.idl

	public class HashChangeEvent : Event
	{
		protected internal HashChangeEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string oldURL => Get<string>();
		public string newURL => Get<string>();
	}
}