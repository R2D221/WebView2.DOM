using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/ui_event.idl

	public class UIEvent : Event
	{
		private protected UIEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public Window? view => Get<Window?>();
		//public int detail => Get<int>();
		public InputDeviceCapabilities? sourceCapabilities => Get<InputDeviceCapabilities?>();

		//public uint which => Get<uint>();
	}
}