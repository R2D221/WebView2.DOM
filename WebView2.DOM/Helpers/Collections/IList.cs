//namespace WebView2.DOM.Collections
//{
//	public interface IList<T> :
//		System.Collections.Generic.IList<T>,
//		ICollection<T>,
//		IReadOnlyList<T>
//	{
//		new T this[int index] { get; set; }

//		T System.Collections.Generic.IList<T>.this[int index]
//		{
//			get => this[index];
//			set => this[index] = value;
//		}

//		T System.Collections.Generic.IReadOnlyList<T>.this[int index] => this[index];
//	}
//}

using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public abstract partial class SVGList<T>
		: IList<T>
		, IReadOnlyList<T>
		, ICollection
	{
		bool ICollection<T>.IsReadOnly => false;
		void ICollection<T>.CopyTo(T[] array, int arrayIndex) =>
			throw new NotSupportedException();

		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}