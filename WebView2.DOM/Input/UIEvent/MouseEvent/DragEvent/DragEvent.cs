namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/drag_event.idl

	public class DragEvent : MouseEvent
	{
		public DataTransfer? dataTransfer => Get<DataTransfer?>();
	}
}