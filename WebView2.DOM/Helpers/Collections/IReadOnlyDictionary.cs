using System.Collections.Generic;

namespace WebView2.DOM.Collections
{
	public interface IReadOnlyDictionary<TKey, TValue> :
		System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>,
		IReadOnlyCollection<KeyValuePair<TKey, TValue>>
		where TKey : notnull
	{
	}
}
