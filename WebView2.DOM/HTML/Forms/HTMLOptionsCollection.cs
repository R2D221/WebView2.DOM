using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_options_collection.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class HTMLOptionsCollection : HTMLCollection<HTMLOptionElement>, IList<HTMLOptionElement>
	{
		protected internal HTMLOptionsCollection(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public int selectedIndex { get => Get<int>(); set => Set(value); }

		public HTMLOptionElement this[int index]
		{
			get => IndexerGet<HTMLOptionElement?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
			set => IndexerSet(index, value);
		}

		public void Add(HTMLOptionElement item) => Method("add").Invoke(item);
		public void Add(HTMLOptionElement item, HTMLElement before) => Method("add").Invoke(item, before);
		public void Add(HTMLOptGroupElement items) => Method("add").Invoke(items);
		public void Add(HTMLOptGroupElement items, HTMLElement before) => Method("add").Invoke(items, before);

		public void Clear() => Set(0, "length");

		public int IndexOf(HTMLOptionElement item) =>
			this
			.Select((value, index) => (value, index))
			.Where(x => x.value == item)
			.Select(x => x.index)
			.DefaultIfEmpty(-1)
			.First();

		public void Insert(int index, HTMLOptionElement item) =>
			Method("add").Invoke(item, index);
		public void Insert(int index, HTMLOptGroupElement item) =>
			Method("add").Invoke(item, index);

		public bool Remove(HTMLOptionElement item)
		{
			switch (IndexOf(item))
			{
			case -1:
			{
				return false;
			}
			case var index:
			{
				RemoveAt(index);
				return true;
			}
			}
		}

		public void RemoveAt(int index) => Method("remove").Invoke(index);

		#region Explicit implementations
		bool ICollection<HTMLOptionElement>.IsReadOnly => false;
		bool ICollection<HTMLOptionElement>.Contains(HTMLOptionElement item) => this.Any(x => x == item);
		void ICollection<HTMLOptionElement>.CopyTo(HTMLOptionElement[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		#endregion
	}
}