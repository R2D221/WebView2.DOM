using Microsoft.Web.WebView2.Core;
using OneOf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_unparsed_value.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class CSSUnparsedValue : CSSStyleValue, ICollection<OneOf<string, CSSVariableReferenceValue>>, IReadOnlyCollection<OneOf<string, CSSVariableReferenceValue>>
	{
		protected internal CSSUnparsedValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSUnparsedValue(IReadOnlyList<OneOf<string, CSSVariableReferenceValue>> members)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(members);

		public OneOf<string, CSSVariableReferenceValue> this[uint index]
		{
			get => IndexerGet<OneOf<string, CSSVariableReferenceValue>?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
			set => IndexerSet(index, value);
		}

		public uint length => Get<uint>();

		public Iterator<OneOf<string, CSSVariableReferenceValue>> GetEnumerator() =>
			SymbolMethod<Iterator<OneOf<string, CSSVariableReferenceValue>>>("iterator").Invoke();

		int IReadOnlyCollection<OneOf<string, CSSVariableReferenceValue>>.Count => (int)length;
		int ICollection<OneOf<string, CSSVariableReferenceValue>>.Count => (int)length;
		bool ICollection<OneOf<string, CSSVariableReferenceValue>>.IsReadOnly => false;
		void ICollection<OneOf<string, CSSVariableReferenceValue>>.Add(OneOf<string, CSSVariableReferenceValue> item) => this[length] = item;
		void ICollection<OneOf<string, CSSVariableReferenceValue>>.Clear() => throw new NotSupportedException();
		bool ICollection<OneOf<string, CSSVariableReferenceValue>>.Contains(OneOf<string, CSSVariableReferenceValue> item) => this.Any(x => x == item);
		void ICollection<OneOf<string, CSSVariableReferenceValue>>.CopyTo(OneOf<string, CSSVariableReferenceValue>[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<OneOf<string, CSSVariableReferenceValue>>.Remove(OneOf<string, CSSVariableReferenceValue> item) => throw new NotSupportedException();
		IEnumerator<OneOf<string, CSSVariableReferenceValue>> IEnumerable<OneOf<string, CSSVariableReferenceValue>>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
