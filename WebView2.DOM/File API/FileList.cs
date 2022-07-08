using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/fileapi/file_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed partial class FileList : JsObject, IReadOnlyCollection<File>
	{
		private FileList() { }

		//public File this[uint index] =>
		//	IndexerGet<File?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public int Count => Get<int>("length");

		public IEnumerator<File> GetEnumerator() =>
			SymbolMethod<Iterator<File>>("iterator").Invoke();
	}
}
