using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
#if DEBUG
#error Incomplete
#endif
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/font_face_set.idl

	public class FontFaceSet : EventTarget
	{
		protected internal FontFaceSet(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
