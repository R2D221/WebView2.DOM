using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/modules/storage/storage.idl

	public class Storage : JsObject, WebView2.DOM.Collections.IDictionary<string, string>
	{
		protected internal Storage(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		private uint length => Get<uint>();
		private string? key(uint index) => Method<string?>().Invoke(index);
		private string? getItem(string key) => Method<string?>().Invoke(key);
		private void setItem(string key, string value) => Method().Invoke(key, value);
		private void removeItem(string key) => Method().Invoke(key);
		private void clear() => Method().Invoke();

		public int Count => (int)length;

		public string this[string key]
		{
			get => getItem(key) ?? throw new KeyNotFoundException();
			set => setItem(key, value);
		}

		public ICollection<string> Keys => new KeyCollection(this);

		public ICollection<string> Values => new ValueCollection(this);

		public void Add(string key, string value)
		{
			if (ContainsKey(key))
			{
				throw new ArgumentException($"An item with the same key has already been added. Key: {key}");
			}
			setItem(key, value);
		}

		public void Clear() => clear();

		public bool ContainsKey(string key) => getItem(key) is not null;

		public bool Remove(string key)
		{
			if (ContainsKey(key))
			{
				removeItem(key);
				return true;
			}
			return false;
		}

		public bool TryGetValue(string key, out string value)
		{
			value = getItem(key)!;
			return value is not null;
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			for (uint i = 0; i < Count; i++)
			{
				var _key = key(i)!;
				var _value = getItem(_key)!;
				yield return KeyValuePair.Create(_key, _value);
			}
		}

		void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item) =>
			Add(item.Key, item.Value);
		bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item) =>
			TryGetValue(item.Key, out var value) && item.Value == value;
		bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
		{
			if (((ICollection<KeyValuePair<string, string>>)this).Contains(item))
			{
				removeItem(item.Key);
				return true;
			}
			return false;
		}

		public struct KeyCollection : ICollection<string>, ICollection, IReadOnlyCollection<string>
		{
			private readonly Storage @this;

			internal KeyCollection(Storage @this) => this.@this = @this;

			public int Count => @this.Count;

			public bool Contains(string item) => @this.ContainsKey(item);

			public IEnumerator<string> GetEnumerator()
			{
				for (uint i = 0; i < @this.Count; i++)
				{
					yield return @this.key(i)!;
				}
			}

			bool ICollection<string>.IsReadOnly => true;
			bool ICollection.IsSynchronized => false;
			object ICollection.SyncRoot => null!;
			void ICollection.CopyTo(Array array, int index) => throw new NotSupportedException();
			void ICollection<string>.Add(string item) => throw new NotSupportedException();
			void ICollection<string>.Clear() => throw new NotSupportedException();
			void ICollection<string>.CopyTo(string[] array, int arrayIndex) => throw new NotSupportedException();
			bool ICollection<string>.Remove(string item) => throw new NotSupportedException();
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public struct ValueCollection : ICollection<string>, ICollection, IReadOnlyCollection<string>
		{
			private readonly Storage @this;

			internal ValueCollection(Storage @this) => this.@this = @this;

			public int Count => @this.Count;

			public IEnumerator<string> GetEnumerator()
			{
				for (uint i = 0; i < @this.Count; i++)
				{
					yield return @this.getItem(@this.key(i)!)!;
				}
			}

			bool ICollection<string>.IsReadOnly => true;
			bool ICollection.IsSynchronized => false;
			object ICollection.SyncRoot => null!;
			void ICollection.CopyTo(Array array, int index) => throw new NotSupportedException();
			bool ICollection<string>.Contains(string item) => @this.Any(x => x.Value == item);
			void ICollection<string>.Add(string item) => throw new NotSupportedException();
			void ICollection<string>.Clear() => throw new NotSupportedException();
			void ICollection<string>.CopyTo(string[] array, int arrayIndex) => throw new NotSupportedException();
			bool ICollection<string>.Remove(string item) => throw new NotSupportedException();
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}
