namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/input/input_device_capabilities.idl

	public sealed class InputDeviceCapabilities : JsObject
	{
		private InputDeviceCapabilities() { }

		public bool firesTouchEvents => Get<bool>();
	}
}
