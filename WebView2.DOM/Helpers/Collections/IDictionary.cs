using System.Collections.Generic;

namespace WebView2.DOM.Collections
{
	public interface IDictionary<TKey, TValue> :
		System.Collections.Generic.IDictionary<TKey, TValue>,
		IReadOnlyDictionary<TKey, TValue>,
		ICollection<KeyValuePair<TKey, TValue>>
	{
		new System.Collections.Generic.ICollection<TKey> Keys { get; }
		new System.Collections.Generic.ICollection<TValue> Values { get; }

		IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>.Keys => this.Keys;
		IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>.Values => this.Values;

		System.Collections.Generic.ICollection<TKey> System.Collections.Generic.IDictionary<TKey, TValue>.Keys => this.Keys;
		System.Collections.Generic.ICollection<TValue> System.Collections.Generic.IDictionary<TKey, TValue>.Values => this.Values;
	}
}
