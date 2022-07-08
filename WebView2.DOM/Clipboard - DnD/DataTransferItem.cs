using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/clipboard/data_transfer_item.idl

	public enum DataTransferItemKind { file, @string }

	public sealed class DataTransferItem : JsObject
	{
		private DataTransferItem() { }

		public DataTransferItemKind kind => Get<DataTransferItemKind>();
		public string type => Get<string>();
		public void getAsString(Action<string> callback) => Method().Invoke(callback);
		public File? getAsFile() => Method<File?>().Invoke();
	}
}
