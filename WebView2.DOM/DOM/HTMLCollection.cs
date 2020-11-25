using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_collection.idl

	public sealed class HTMLCollection : JsObject
	{
		internal HTMLCollection(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class HTMLCollection<TElement> : JsObject, ICollection<TElement>, IReadOnlyCollection<TElement>
		where TElement : Element
	{
		public static implicit operator HTMLCollection<TElement>(HTMLCollection htmlCollection) =>
			new HTMLCollection<TElement>(htmlCollection);

		internal HTMLCollection(HTMLCollection htmlCollection)
			: base(htmlCollection.coreWebView, htmlCollection.referenceId)
		{
			References.Update(target: this);
		}

		public TElement this[uint index] =>
			IndexerGet<TElement?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public TElement this[string name] =>
			IndexerGet<TElement?>(name) ?? throw new ArgumentException(message: null, paramName: nameof(name));
		public uint length => Get<uint>();

		public Iterator<TElement> GetEnumerator() =>
			SymbolMethod<Iterator<TElement>>("iterator").Invoke();

		int IReadOnlyCollection<TElement>.Count => (int)length;
		int ICollection<TElement>.Count => (int)length;
		bool ICollection<TElement>.IsReadOnly => true;
		void ICollection<TElement>.Add(TElement item) => throw new NotSupportedException();
		void ICollection<TElement>.Clear() => throw new NotSupportedException();
		bool ICollection<TElement>.Contains(TElement item) => this.Any(x => x == item);
		void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<TElement>.Remove(TElement item) => throw new NotSupportedException();
		IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
