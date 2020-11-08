namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/media_query_list_event.idl

	public class MediaQueryListEvent : Event
	{
		public string media => Get<string>();
		public bool matches => Get<bool>();
	}
}
