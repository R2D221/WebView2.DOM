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

	public sealed class MediaError : JsObject
	{
		private MediaError() { }

		public MediaErrorCode code => Get<MediaErrorCode>();
		public string message => Get<string>();
	}
}