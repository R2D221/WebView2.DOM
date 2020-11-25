using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/input/input_device_capabilities.idl

	public class InputDeviceCapabilities : JsObject
	{
		protected internal InputDeviceCapabilities(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool firesTouchEvents => Get<bool>();
	}
}
