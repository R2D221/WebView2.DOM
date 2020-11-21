using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/media_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class MediaList : JsObject, ICollection<string>, IReadOnlyCollection<string>
	{
		public string mediaText { get => Get<string>(); set => Set(value); }
		public string this[uint index] =>
			IndexerGet<string?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();
		public void appendMedium(string medium) => Method().Invoke(medium);
		public void deleteMedium(string medium) => Method().Invoke(medium);

		public Iterator<string> GetEnumerator() =>
			SymbolMethod<Iterator<string>>("iterator").Invoke();

		int IReadOnlyCollection<string>.Count => (int)length;
		int ICollection<string>.Count => (int)length;
		bool ICollection<string>.IsReadOnly => false;
		void ICollection<string>.Add(string item) => appendMedium(item);
		void ICollection<string>.Clear() { foreach (var item in this.ToArray()) { deleteMedium(item); } }
		bool ICollection<string>.Contains(string item) => this.Any(x => x == item);
		void ICollection<string>.CopyTo(string[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<string>.Remove(string item) { deleteMedium(item); return true; }
		IEnumerator<string> IEnumerable<string>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
