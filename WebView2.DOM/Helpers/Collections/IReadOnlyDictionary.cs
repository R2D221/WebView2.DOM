//using System.Collections.Generic;

//namespace WebView2.DOM.Collections
//{
//	public interface IReadOnlyDictionary<TKey, TValue> :
//		System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>,
//		IReadOnlyCollection<KeyValuePair<TKey, TValue>>
//		where TKey : notnull
//	{
//	}
//}

using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public partial class StylePropertyMapReadOnly
		: IReadOnlyDictionary<string, IReadOnlyList<CSSStyleValue>>
		, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}