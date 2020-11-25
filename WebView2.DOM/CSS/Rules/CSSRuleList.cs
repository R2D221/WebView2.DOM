using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_rule_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class CSSRuleList : JsObject, ICollection<CSSRule>, IReadOnlyCollection<CSSRule>
	{
		protected internal CSSRuleList(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSRule this[uint index] =>
			IndexerGet<CSSRule?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();

		public Iterator<CSSRule> GetEnumerator() =>
			SymbolMethod<Iterator<CSSRule>>("iterator").Invoke();

		int IReadOnlyCollection<CSSRule>.Count => (int)length;
		int ICollection<CSSRule>.Count => (int)length;
		bool ICollection<CSSRule>.IsReadOnly => true;
		void ICollection<CSSRule>.Add(CSSRule item) => throw new NotSupportedException();
		void ICollection<CSSRule>.Clear() => throw new NotSupportedException();
		bool ICollection<CSSRule>.Contains(CSSRule item) => this.Any(x => x == item);
		void ICollection<CSSRule>.CopyTo(CSSRule[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<CSSRule>.Remove(CSSRule item) => throw new NotSupportedException();
		IEnumerator<CSSRule> IEnumerable<CSSRule>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
