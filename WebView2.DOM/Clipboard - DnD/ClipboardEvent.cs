using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/clipboard_event.idl

	public sealed class ClipboardEvent : Event
	{
		private ClipboardEvent() { }

		public DataTransfer? clipboardData => Get<DataTransfer?>();
	}
}
