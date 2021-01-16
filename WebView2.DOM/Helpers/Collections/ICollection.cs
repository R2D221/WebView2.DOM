using System;

namespace WebView2.DOM.Collections
{
	public interface ICollection<T> :
		System.Collections.Generic.ICollection<T>,
		IReadOnlyCollection<T>
	{
		new int Count { get; }

		int IReadOnlyCollection<T>.Count => Count;

		int System.Collections.Generic.ICollection<T>.Count => Count;
		bool System.Collections.Generic.ICollection<T>.IsReadOnly => false;
		void System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex) =>
			throw new NotSupportedException();
	}
}
