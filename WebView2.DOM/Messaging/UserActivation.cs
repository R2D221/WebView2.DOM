﻿using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/user_activation.idl

	[Obsolete("not tested")]
	public class UserActivation : JsObject
	{
		public bool hasBeenActive => Get<bool>();
		public bool isActive => Get<bool>();
	}
}