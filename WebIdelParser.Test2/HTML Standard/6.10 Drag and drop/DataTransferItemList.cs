using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public partial class DataTransferItemList : ICollection<DataTransferItem>
	{
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

#warning Make another source generator for this
	public partial class DataTransferItemList
	: ICollection<DataTransferItem>
	, IReadOnlyCollection<DataTransferItem>
	, ICollection
	{
		bool ICollection<DataTransferItem>.IsReadOnly => false;
		void ICollection<DataTransferItem>.CopyTo(DataTransferItem[] array, int arrayIndex) =>
			throw new NotSupportedException();
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}