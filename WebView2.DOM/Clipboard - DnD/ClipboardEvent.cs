namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/clipboard_event.idl

	public class ClipboardEvent : Event
	{
		public DataTransfer? clipboardData => Get<DataTransfer?>();
	}
}
