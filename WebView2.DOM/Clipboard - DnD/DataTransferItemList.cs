using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/clipboard/data_transfer_item_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class DataTransferItemList : JsObject, ICollection<DataTransferItem>, IReadOnlyCollection<DataTransferItem>
	{
		public DataTransferItem this[uint index] =>
			IndexerGet<DataTransferItem?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();
		public DataTransferItem? add(string data, string type) =>
			Method<DataTransferItem?>().Invoke(data, type);
		public DataTransferItem? add(File file) =>
			Method<DataTransferItem?>().Invoke(file);
		private void remove(uint index) => Method().Invoke(index);
		public void clear() => Method().Invoke();

		public int RemoveWhere(Func<DataTransferItem, bool> match)
		{
			var itemsToRemove =
				this.Select((item, index) => (item, index: (uint)index))
				.Reverse()
				.Where(x => match(x.item))
				.ToImmutableArray();

			foreach (var (item, index) in itemsToRemove)
			{
				remove(index);
			}

			return itemsToRemove.Length;
		}

		public Iterator<DataTransferItem> GetEnumerator() =>
			SymbolMethod<Iterator<DataTransferItem>>("iterator").Invoke();

		int IReadOnlyCollection<DataTransferItem>.Count => (int)length;
		int ICollection<DataTransferItem>.Count => (int)length;
		bool ICollection<DataTransferItem>.IsReadOnly => false;
		void ICollection<DataTransferItem>.Add(DataTransferItem item) => throw new NotSupportedException();
		void ICollection<DataTransferItem>.Clear() => clear();
		bool ICollection<DataTransferItem>.Contains(DataTransferItem item) => throw new NotSupportedException();
		void ICollection<DataTransferItem>.CopyTo(DataTransferItem[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<DataTransferItem>.Remove(DataTransferItem item) => throw new NotSupportedException();
		IEnumerator<DataTransferItem> IEnumerable<DataTransferItem>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
