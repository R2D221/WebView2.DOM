using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/user_activation.idl

	public sealed class UserActivation : JsObject
	{
		private UserActivation() { }

		public bool hasBeenActive => Get<bool>();
		public bool isActive => Get<bool>();
	}
}
