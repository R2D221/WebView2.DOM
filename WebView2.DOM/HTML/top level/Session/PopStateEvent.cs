using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/pop_state_event.idl

	public class PopStateEvent : Event
	{
		protected internal PopStateEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public dynamic state => Get<any>();
	}
}