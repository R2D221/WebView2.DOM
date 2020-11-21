using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/fileapi/file_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class FileList : JsObject, ICollection<File>, IReadOnlyCollection<File>
	{
		public File this[uint index] =>
			IndexerGet<File?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();

		public Iterator<File> GetEnumerator() =>
			SymbolMethod<Iterator<File>>("iterator").Invoke();

		int IReadOnlyCollection<File>.Count => (int)length;
		int ICollection<File>.Count => (int)length;
		bool ICollection<File>.IsReadOnly => true;
		void ICollection<File>.Add(File item) => throw new NotSupportedException();
		void ICollection<File>.Clear() => throw new NotSupportedException();
		bool ICollection<File>.Contains(File item) => this.Any(x => x == item);
		void ICollection<File>.CopyTo(File[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<File>.Remove(File item) => throw new NotSupportedException();
		IEnumerator<File> IEnumerable<File>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
