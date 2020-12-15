using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/font_face_set.idl

	public class FontFaceSet : EventTarget
	{
		protected internal FontFaceSet(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}

		public FontFaceSet() : this(null!, null!) { }
	}
}
