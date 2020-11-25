using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/clipboard/data_transfer_item.idl

	public enum DataTransferItemKind { file, @string }

	public class DataTransferItem : JsObject
	{
		protected internal DataTransferItem(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public DataTransferItemKind kind => Get<DataTransferItemKind>();
		public string type => Get<string>();
		public void getAsString(Action<string> callback) => Method().Invoke(callback);
		public File? getAsFile() => Method<File?>().Invoke();
	}
}
