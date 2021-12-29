using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/dom_token_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public partial class DOMTokenList : JsObject, ICollection<string>
	{
		protected internal DOMTokenList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		//private string this[uint index] =>
		//	IndexerGet<string?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		private uint length => Get<uint>();
		private bool contains(string token) => Method<bool>().Invoke(token);
		private void add(params string[] tokens) => Method().Invoke(args: tokens);
		private void remove(params string[] tokens) => Method().Invoke(args: tokens);

		public bool toggle(string token) => Method<bool>().Invoke(token);
		public bool toggle(string token, bool force) => Method<bool>().Invoke(token, force);
		public bool replace(string oldToken, string newToken) => Method<bool>().Invoke(oldToken, newToken);
		public bool supports(string token) => Method<bool>().Invoke(token);
		public string value { get => Get<string>(); set => Set(value); }

		public int Count => (int)length;
		public void Add(string item) => add(item);
		public void Clear() => value = "";
		public bool Contains(string item) => contains(item);

		public bool Remove(string item)
		{
			var result = contains(item);
			remove(item);
			return result;
		}

		public IEnumerator<string> GetEnumerator() =>
			SymbolMethod<Iterator<string>>("iterator").Invoke();
	}
}
