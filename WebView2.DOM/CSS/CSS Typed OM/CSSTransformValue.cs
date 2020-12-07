using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_transform_value.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class CSSTransformValue : CSSStyleValue, ICollection<CSSTransformValue>, IReadOnlyCollection<CSSTransformValue>
	{
		protected internal CSSTransformValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSTransformValue(IReadOnlyList<CSSTransformComponent> transforms)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(transforms);

		public CSSTransformValue this[uint index]
		{
			get => IndexerGet<CSSTransformValue?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
			set => IndexerSet(index, value);
		}

		public uint length => Get<uint>();

		public bool is2D => Get<bool>();
		public DOMMatrix toMatrix() => Method<DOMMatrix>().Invoke();

		public Iterator<CSSTransformValue> GetEnumerator() =>
			SymbolMethod<Iterator<CSSTransformValue>>("iterator").Invoke();

		int IReadOnlyCollection<CSSTransformValue>.Count => (int)length;
		int ICollection<CSSTransformValue>.Count => (int)length;
		bool ICollection<CSSTransformValue>.IsReadOnly => false;
		void ICollection<CSSTransformValue>.Add(CSSTransformValue item) => this[length] = item;
		void ICollection<CSSTransformValue>.Clear() => throw new NotSupportedException();
		bool ICollection<CSSTransformValue>.Contains(CSSTransformValue item) => this.Any(x => x == item);
		void ICollection<CSSTransformValue>.CopyTo(CSSTransformValue[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<CSSTransformValue>.Remove(CSSTransformValue item) => throw new NotSupportedException();
		IEnumerator<CSSTransformValue> IEnumerable<CSSTransformValue>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
