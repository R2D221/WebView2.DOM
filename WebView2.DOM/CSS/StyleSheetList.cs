using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/style_sheet_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed partial class StyleSheetList : JsObject, IReadOnlyCollection<StyleSheet>
	{
		private StyleSheetList() { }

		//public StyleSheet this[uint index] =>
		//	IndexerGet<StyleSheet?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public CSSStyleSheet this[string name] =>
			IndexerGet<CSSStyleSheet?>(name) ?? throw new ArgumentException(message: null, paramName: nameof(name));

		public int Count => Get<int>("length");

		public IEnumerator<StyleSheet> GetEnumerator() =>
			SymbolMethod<Iterator<StyleSheet>>("iterator").Invoke();
	}
}