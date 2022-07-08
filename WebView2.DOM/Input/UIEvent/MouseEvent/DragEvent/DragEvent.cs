using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/drag_event.idl

	public sealed class DragEvent : MouseEvent
	{
		private DragEvent() { }

		public DataTransfer? dataTransfer => Get<DataTransfer?>();
	}
}