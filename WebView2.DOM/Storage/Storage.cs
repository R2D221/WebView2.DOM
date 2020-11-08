using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/modules/storage/storage.idl

	public class Storage : JsObject, ICollection<KeyValuePair<string, string>>, IReadOnlyCollection<KeyValuePair<string, string>>
	{
		public uint length => Get<uint>();
		public string? key(uint index) => Method<string?>().Invoke(index);
		public string? getItem(string key) => Method<string?>().Invoke(key);
		public void setItem(string key, string value) => Method().Invoke(key, value);
		public void removeItem(string key) => Method().Invoke(key);
		public void clear() => Method().Invoke();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<KeyValuePair<string, string>> GetEnumerator() =>
			Enumerable.Range(0, (int)length)
			.Select(index => key((uint)index)!)
			.Select(key => KeyValuePair.Create(key, getItem(key)!))
			.GetEnumerator();

		int IReadOnlyCollection<KeyValuePair<string, string>>.Count => (int)length;
		int ICollection<KeyValuePair<string, string>>.Count => (int)length;
		bool ICollection<KeyValuePair<string, string>>.IsReadOnly => false;
		void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item) => setItem(item.Key, item.Value);
		void ICollection<KeyValuePair<string, string>>.Clear() => clear();
		bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item) => getItem(item.Key) == item.Value;
		void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item) { removeItem(item.Key); return true; }
	}
}
