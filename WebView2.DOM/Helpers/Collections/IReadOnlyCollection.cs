using System;

namespace WebView2.DOM.Collections
{
	public interface IReadOnlyCollection<out T> :
		System.Collections.Generic.IReadOnlyCollection<T>,
		System.Collections.ICollection
	{
		new int Count { get; }
		new System.Collections.Generic.IEnumerator<T> GetEnumerator();

		int System.Collections.Generic.IReadOnlyCollection<T>.Count => Count;

		int System.Collections.ICollection.Count => Count;
		bool System.Collections.ICollection.IsSynchronized => false;
		object System.Collections.ICollection.SyncRoot => null!;
		void System.Collections.ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() =>
			GetEnumerator();

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
			GetEnumerator();
	}
}
