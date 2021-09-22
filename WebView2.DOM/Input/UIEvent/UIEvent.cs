using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/ui_event.idl

	public class UIEvent : Event
	{
		protected internal UIEvent(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public Window? view => Get<Window?>();
		//public int detail => Get<int>();
		public InputDeviceCapabilities? sourceCapabilities => Get<InputDeviceCapabilities?>();

		//public uint which => Get<uint>();
	}
}