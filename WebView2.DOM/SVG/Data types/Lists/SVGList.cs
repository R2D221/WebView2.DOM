using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_length_list.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_number_list.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_point_list.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_string_list.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_transform_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public abstract partial class SVGList<T> : JsObject, IList<T>
		where T : class
	{
		private protected SVGList() { }

		public T this[int index]
		{
			get => IndexerGet<T?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
			set => IndexerSet(index, value);
		}

		public int Count => Get<int>("length");

		private bool? isReadOnly;
		public bool IsReadOnly
		{
			get
			{
				return isReadOnly ??= getIsReadOnly();
				bool getIsReadOnly()
				{
					if (Count == 0)
					{
						try { Clear(); return false; }
						catch (NoModificationAllowedError) { return true; }
					}
					else
					{
						try
						{
							Add(this[0]);
							RemoveAt(Count - 1);
							return false;
						}
						catch (NoModificationAllowedError)
						{
							return true;
						}
					}
				}
			}
		}

		public void Add(T item) =>
			Method<T>("appendItem").Invoke(item);

		public void Clear() => Method("clear").Invoke();

		[Obsolete("This list creates a new reference whenever an item is requested, making comparisons impossible", true)]
		public bool Contains(T item) => IndexOf(item) > -1;

		[Obsolete("This list creates a new reference whenever an item is requested, making comparisons impossible", true)]
		public int IndexOf(T item) =>
			throw new NotSupportedException("This list creates a new reference whenever an item is requested, making comparisons impossible");
		//	this
		//	.Select((value, index) => (value, index))
		//	.Where(x => x.value == item)
		//	.Select(x => x.index)
		//	.DefaultIfEmpty(-1)
		//	.First();

		public void Insert(int index, T item) =>
			Method<T>("insertItemBefore").Invoke(item, index);

		[Obsolete("This list creates a new reference whenever an item is requested, making comparisons impossible", true)]
		public bool Remove(T item)
		{
			if (IndexOf(item) is var index && index > -1)
			{
				RemoveAt(index);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void RemoveAt(int index) =>
			Method<T>("removeItem").Invoke(index);

		public IEnumerator<T> GetEnumerator() =>
			SymbolMethod<Iterator<T>>("iterator").Invoke();
	}
}