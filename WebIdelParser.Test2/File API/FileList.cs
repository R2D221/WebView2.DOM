using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public partial class FileList : IReadOnlyCollection<File>
	{
		public int Count => (int)length;

		public IEnumerator<File> GetEnumerator() =>
			SymbolMethod<Iterator<File>>("iterator").Invoke();
	}

#warning Make another source generator for this
	public partial class FileList : IReadOnlyCollection<File>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
