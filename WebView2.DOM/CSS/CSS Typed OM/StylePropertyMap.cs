using OneOf;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/style_property_map_read_only.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public partial class StylePropertyMapReadOnly : JsObject
		//, IEnumerable<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>>
		, IReadOnlyDictionary<string, IReadOnlyList<CSSStyleValue>>
	{
		private protected StylePropertyMapReadOnly() { }

		public int Count => Get<int>("size");

		public IReadOnlyList<CSSStyleValue> this[string property] =>
			Method<ImmutableArray<CSSStyleValue>>("getAll").Invoke(property);

		public IEnumerable<string> Keys =>
			this.Select(x => x.Key);

		public IEnumerable<IReadOnlyList<CSSStyleValue>> Values =>
			this.Select(x => x.Value);

		public bool ContainsKey(string property) =>
			Method<bool>("has").Invoke(property);

		public IEnumerator<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>> GetEnumerator() =>
			SymbolMethod<Iterator<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>>>("iterator").Invoke();

		public bool TryGetValue(string property, out IReadOnlyList<CSSStyleValue> value)
		{
			value = this[property];
			return ContainsKey(property);
		}
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/style_property_map.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class StylePropertyMap : StylePropertyMapReadOnly
	{
		private StylePropertyMap() { }

		public void set(string property, params OneOf<CSSStyleValue, string>[] values) =>
			Method().Invoke(args: new[] { property }.Concat(values.Select(x => x.Value)).ToArray());
		public void append(string property, params OneOf<CSSStyleValue, string>[] values) =>
			Method().Invoke(args: new[] { property }.Concat(values.Select(x => x.Value)).ToArray());
		public void delete(string property) => Method().Invoke(property);
		public void clear() => Method().Invoke();
	}
}
