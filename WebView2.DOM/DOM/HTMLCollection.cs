using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_collection.idl

	public sealed class HTMLCollection : JsObject
	{
		internal HTMLCollection(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class HTMLCollection<TElement> : JsObject, IReadOnlyCollection<TElement>
	{
		protected internal HTMLCollection(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public static implicit operator HTMLCollection<TElement>(HTMLCollection htmlCollection) =>
			new HTMLCollection<TElement>(htmlCollection);

		internal HTMLCollection(HTMLCollection htmlCollection)
			: base(htmlCollection.coreWebView, htmlCollection.referenceId)
		{
			References.Update(target: this);
		}

		public TElement this[string name] =>
			IndexerGet<TElement?>(name) ?? throw new ArgumentException(message: null, paramName: nameof(name));

		public int Count => Get<int>("length");

		public Iterator<TElement> GetEnumerator() =>
			SymbolMethod<Iterator<TElement>>("iterator").Invoke();

		IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
