using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/media/media_error.idl

	public enum MediaErrorCode : ushort
	{
		ABORTED = 1,
		NETWORK = 2,
		DECODE = 3,
		SRC_NOT_SUPPORTED = 4,
	}

	public class MediaError : JsObject
	{
		protected internal MediaError(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public MediaErrorCode code => Get<MediaErrorCode>();
		public string message => Get<string>();
	}
}