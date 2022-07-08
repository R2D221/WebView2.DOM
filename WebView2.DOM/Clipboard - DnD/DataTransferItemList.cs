using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/clipboard/data_transfer_item_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed partial class DataTransferItemList : JsObject, ICollection<DataTransferItem>
	{
		private DataTransferItemList() { }

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

		public IEnumerator<DataTransferItem> GetEnumerator() =>
			SymbolMethod<Iterator<DataTransferItem>>("iterator").Invoke();

		public int Count => (int)length;
		void ICollection<DataTransferItem>.Add(DataTransferItem item) => throw new NotSupportedException();
		void ICollection<DataTransferItem>.Clear() => clear();
		bool ICollection<DataTransferItem>.Contains(DataTransferItem item) => throw new NotSupportedException();
		bool ICollection<DataTransferItem>.Remove(DataTransferItem item) => throw new NotSupportedException();
	}
}
