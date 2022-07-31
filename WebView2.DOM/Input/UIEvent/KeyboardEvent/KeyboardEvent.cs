using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/keyboard_event.idl

	public enum KeyLocation : uint
	{
		STANDARD/*	*/= 0,
		LEFT/*	*/= 1,
		RIGHT/*	*/= 2,
		NUMPAD/*	*/= 3,
	}

	public sealed class KeyboardEvent : UIEvent
	{
		private KeyboardEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public string key => Get<string>();
		public string code => Get<string>();
		public KeyLocation location => Get<KeyLocation>();
		public bool ctrlKey => Get<bool>();
		public bool shiftKey => Get<bool>();
		public bool altKey => Get<bool>();
		public bool metaKey => Get<bool>();
		public bool repeat => Get<bool>();
		public bool isComposing => Get<bool>();
		public bool getModifierState(string keyArg) => Method<bool>().Invoke(keyArg);

		//public int charCode => Get<int>();
		//public int keyCode => Get<int>();
	}
}