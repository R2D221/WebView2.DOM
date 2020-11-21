using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/dom_token_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class DOMTokenList : JsObject, ICollection<string>, IReadOnlyCollection<string>
	{
		public string this[uint index] =>
			IndexerGet<string?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();
		public bool contains(string token) => Method<bool>().Invoke(token);
		public void add(params string[] tokens) => Method().Invoke(args: tokens);
		public void remove(params string[] tokens) => Method().Invoke(args: tokens);
		public bool toggle(string token) => Method<bool>().Invoke(token);
		public bool toggle(string token, bool force) => Method<bool>().Invoke(token, force);
		public bool replace(string oldToken, string newToken) => Method<bool>().Invoke(oldToken, newToken);
		public bool supports(string token) => Method<bool>().Invoke(token);
		public string value { get => Get<string>(); set => Set(value); }

		public Iterator<string> GetEnumerator() =>
			SymbolMethod<Iterator<string>>("iterator").Invoke();

		int IReadOnlyCollection<string>.Count => (int)length;
		int ICollection<string>.Count => (int)length;
		bool ICollection<string>.IsReadOnly => false;
		void ICollection<string>.Add(string item) => add(item);
		void ICollection<string>.Clear() => remove(this.ToArray());
		bool ICollection<string>.Contains(string item) => contains(item);
		void ICollection<string>.CopyTo(string[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<string>.Remove(string item) { remove(item); return true; }
		IEnumerator<string> IEnumerable<string>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
