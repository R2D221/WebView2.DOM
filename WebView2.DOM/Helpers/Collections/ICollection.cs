//using System;

//namespace WebView2.DOM.Collections
//{
//	public interface ICollection<T> :
//		System.Collections.Generic.ICollection<T>,
//		IReadOnlyCollection<T>
//	{
//		new int Count { get; }

//		int IReadOnlyCollection<T>.Count => Count;

//		int System.Collections.Generic.ICollection<T>.Count => Count;
//		bool System.Collections.Generic.ICollection<T>.IsReadOnly => false;
//		void System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex) =>
//			throw new NotSupportedException();
//	}
//}

using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
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

	public partial class MediaList
		: ICollection<string>
		, IReadOnlyCollection<string>
		, ICollection
	{
		bool ICollection<string>.IsReadOnly => false;
		void ICollection<string>.CopyTo(string[] array, int arrayIndex) =>
			throw new NotSupportedException();
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class DOMTokenList
		: ICollection<string>
		, IReadOnlyCollection<string>
		, ICollection
	{
		bool ICollection<string>.IsReadOnly => false;
		void ICollection<string>.CopyTo(string[] array, int arrayIndex) =>
			throw new NotSupportedException();
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
