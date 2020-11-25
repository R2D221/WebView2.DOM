using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/drag_event.idl

	public class DragEvent : MouseEvent
	{
		protected internal DragEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public DataTransfer? dataTransfer => Get<DataTransfer?>();
	}
}