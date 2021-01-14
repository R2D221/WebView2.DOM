using System;

namespace WebView2.DOM
{
	public interface IReadOnlyCollection<T> : System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.ICollection
	{
		new int Count { get; }

		int System.Collections.Generic.IReadOnlyCollection<T>.Count => Count;

		int System.Collections.ICollection.Count => Count;

		bool System.Collections.ICollection.IsSynchronized => false;
		object System.Collections.ICollection.SyncRoot => null!;
		void System.Collections.ICollection.CopyTo(Array array, int index) => throw new NotSupportedException();
	}
}
