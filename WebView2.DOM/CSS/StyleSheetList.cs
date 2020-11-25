using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/style_sheet_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class StyleSheetList : JsObject, ICollection<StyleSheet>, IReadOnlyCollection<StyleSheet>
	{
		protected internal StyleSheetList(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public StyleSheet this[uint index] =>
			IndexerGet<StyleSheet?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public CSSStyleSheet this[string name] =>
			IndexerGet<CSSStyleSheet?>(name) ?? throw new ArgumentException(message: null, paramName: nameof(name));
		public uint length => Get<uint>();

		public Iterator<StyleSheet> GetEnumerator() =>
			SymbolMethod<Iterator<StyleSheet>>("iterator").Invoke();

		int IReadOnlyCollection<StyleSheet>.Count => (int)length;
		int ICollection<StyleSheet>.Count => (int)length;
		bool ICollection<StyleSheet>.IsReadOnly => true;
		void ICollection<StyleSheet>.Add(StyleSheet item) => throw new NotSupportedException();
		void ICollection<StyleSheet>.Clear() => throw new NotSupportedException();
		bool ICollection<StyleSheet>.Contains(StyleSheet item) => this.Any(x => x == item);
		void ICollection<StyleSheet>.CopyTo(StyleSheet[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<StyleSheet>.Remove(StyleSheet item) => throw new NotSupportedException();
		IEnumerator<StyleSheet> IEnumerable<StyleSheet>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}