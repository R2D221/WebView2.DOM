//using System.Collections.Generic;

//namespace WebView2.DOM.Collections
//{
//	public interface IDictionary<TKey, TValue> :
//		System.Collections.Generic.IDictionary<TKey, TValue>,
//		IReadOnlyDictionary<TKey, TValue>,
//		ICollection<KeyValuePair<TKey, TValue>>
//		where TKey : notnull
//	{
//		new System.Collections.Generic.ICollection<TKey> Keys { get; }
//		new System.Collections.Generic.ICollection<TValue> Values { get; }

//		IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>.Keys => this.Keys;
//		IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>.Values => this.Values;

//		System.Collections.Generic.ICollection<TKey> System.Collections.Generic.IDictionary<TKey, TValue>.Keys => this.Keys;
//		System.Collections.Generic.ICollection<TValue> System.Collections.Generic.IDictionary<TKey, TValue>.Values => this.Values;
//	}
//}

using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public partial class Storage
		: IDictionary<string, string>
		, IReadOnlyDictionary<string, string>
		, ICollection
	{
		IEnumerable<string> IReadOnlyDictionary<string, string>.Keys => Keys;
		IEnumerable<string> IReadOnlyDictionary<string, string>.Values => Values;

		bool ICollection<KeyValuePair<string, string>>.IsReadOnly => false;
		void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex) =>
			throw new NotSupportedException();

		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
