using OneOf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/style_property_map_read_only.idl

	public class StylePropertyMapReadOnly : JsObject, IEnumerable<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>>
	{
		public CSSStyleValue? get(string property) => Method<CSSStyleValue?>().Invoke(property);
		public IReadOnlyList<CSSStyleValue> getAll(string property) =>
			Method<ImmutableArray<CSSStyleValue>>().Invoke(property);
		public bool has(string property) => Method<bool>().Invoke(property);
		public uint size => Get<uint>();

		public Iterator<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>> GetEnumerator() =>
			SymbolMethod<Iterator<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>>>("iterator").Invoke();

		IEnumerator<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>> IEnumerable<KeyValuePair<string, IReadOnlyList<CSSStyleValue>>>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/style_property_map.idl

	public class StylePropertyMap : StylePropertyMapReadOnly
	{
		public void set(string property, params OneOf<CSSStyleValue, string>[] values) =>
			Method().Invoke(args: values.Select(x => x.Value).Prepend(property).ToArray());
		public void append(string property, params OneOf<CSSStyleValue, string>[] values) =>
			Method().Invoke(args: values.Select(x => x.Value).Prepend(property).ToArray());
		public void delete(string property) => Method().Invoke(property);
		public void clear() => Method().Invoke();
	}

	public class CSSStyleValue : JsObject
	{
		//#error
	}

	public class CSSKeywordValue : CSSStyleValue { }
	public class CSSPositionValue : CSSStyleValue { }
}
