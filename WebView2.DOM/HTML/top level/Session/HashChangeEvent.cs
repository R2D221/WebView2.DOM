namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/hash_change_event.idl

	public class HashChangeEvent : Event
	{
		public string oldURL => Get<string>();
		public string newURL => Get<string>();
	}
}