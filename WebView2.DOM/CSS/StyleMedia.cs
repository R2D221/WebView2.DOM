using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/style_media.idl

	public class StyleMedia : JsObject
	{
		protected internal StyleMedia(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string type => Get<string>();

		public bool matchMedium(string? mediaquery = "undefined") => Method<bool>().Invoke(mediaquery);
	}
}
