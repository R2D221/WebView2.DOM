using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/clipboard_event.idl

	public class ClipboardEvent : Event
	{
		protected internal ClipboardEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public DataTransfer? clipboardData => Get<DataTransfer?>();
	}
}
