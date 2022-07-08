using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_collection.idl

	public abstract class HTMLCollection : JsObject { }

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public partial class HTMLCollection<TElement> : HTMLCollection, IReadOnlyCollection<TElement>
	{
		private protected HTMLCollection() { }

		public TElement this[string name] =>
			IndexerGet<TElement?>(name) ?? throw new ArgumentException(message: null, paramName: nameof(name));

		public int Count => Get<int>("length");

		public IEnumerator<TElement> GetEnumerator() =>
			SymbolMethod<Iterator<TElement>>("iterator").Invoke();
	}
}
