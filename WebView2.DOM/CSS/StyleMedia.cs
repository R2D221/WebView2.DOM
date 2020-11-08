namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/style_media.idl

	public class StyleMedia : JsObject
	{
		public string type => Get<string>();

		public bool matchMedium(string? mediaquery = "undefined") => Method<bool>().Invoke(mediaquery);
	}
}
