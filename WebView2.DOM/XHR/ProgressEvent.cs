using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/progress_event.idl

	public sealed class ProgressEvent : Event
	{
		private ProgressEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public bool lengthComputable => Get<bool>();
		public ulong loaded => Get<ulong>();
		public ulong total => Get<ulong>();
	}
}