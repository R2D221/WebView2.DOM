namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/modules/storage/storage_event.idl

	public class StorageEvent : Event
	{
		public string? key => Get<string?>();
		public string? oldValue => Get<string?>();
		public string? newValue => Get<string?>();
		public string url => Get<string>();
		public Storage? storageArea => Get<Storage?>();
	}
}