using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/drag_event.idl

	public sealed class DragEvent : MouseEvent
	{
		private DragEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public DataTransfer? dataTransfer => Get<DataTransfer?>();
	}
}