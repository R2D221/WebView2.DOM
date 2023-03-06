using deniszykov.TypeConversion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public abstract class TypedArray : JsObject
	{
		public int BYTES_PER_ELEMENT => _BYTES_PER_ELEMENT;
		protected abstract int _BYTES_PER_ELEMENT { get; }

		public ArrayBuffer buffer => GetCached<ArrayBuffer>();

		public uint byteLength => GetCached<uint>();

		public uint byteOffset => GetCached<uint>();

		public uint length => GetCached<uint>();
	}

	public abstract class PrimitiveTypedArray<TArray, TValue> : TypedArray, IReadOnlyList<TValue>, IList<TValue>, IList
		where TArray : class
		where TValue : struct
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(typeof(TArray).Name);

		public static TArray from(IReadOnlyList<TValue> source) =>
			Static.Method<TArray>().Invoke(source);

		public static TArray from<T>(IReadOnlyList<T> source, Func<T, TValue> mapFn) =>
			Static.Method<TArray>().Invoke(source, mapFn);

		public static TArray from<T>(IReadOnlyList<T> source, Func<T, int, TValue> mapFn) =>
			Static.Method<TArray>().Invoke(source, mapFn);

		public static TArray of(TValue element0) =>
			Static.Method<TArray>().Invoke(element0);

		public static TArray of(TValue element0, TValue element1) =>
			Static.Method<TArray>().Invoke(element0, element1);

		public static TArray of(TValue element0, TValue element1, TValue element2) =>
			Static.Method<TArray>().Invoke(element0, element1, element2);

		public static TArray of(params TValue[] elements) =>
			Static.Method<TArray>().Invoke(args: elements.Select(x => (object?)x).ToArray());

		public Iterator<TValue> GetEnumerator() =>
			SymbolMethod<Iterator<TValue>>("iterator").Invoke();

		public TValue at(int index) =>
			Method<TValue>().Invoke(index);

		public TArray copyWithin(int target, int start) =>
			Method<TArray>().Invoke(target, start);

		public TArray copyWithin(int target, int start, int end) =>
			Method<TArray>().Invoke(target, start, end);

		[Obsolete("Use .Select((x, i) => (x, i)) instead.", true)]
		public object? entries() => throw new NotSupportedException("Use .Select((x, i) => (x, i)) instead.");

		[Obsolete("Use .All() instead.", true)]
		public object? every() => throw new NotSupportedException("Use .All() instead.");

		public TArray fill(TValue value, int start) =>
			Method<TArray>().Invoke(value, start);

		public TArray fill(TValue value, int start, int end) =>
			Method<TArray>().Invoke(value, start, end);

		[Obsolete("Use .Where() instead.", true)]
		public object? filter() => throw new NotSupportedException("Use .Where() instead.");

		[Obsolete("Use .FirstOrDefault(...) instead.", true)]
		public object? find() => throw new NotSupportedException("Use .FirstOrDefault(...) instead.");

		[Obsolete("Use .Select((x, i) => (x, i)).FirstOrDefault(...) instead.", true)]
		public object? findIndex() => throw new NotSupportedException("Use .Select((x, i) => (x, i)).FirstOrDefault(...) instead.");

		[Obsolete("Use .LastOrDefault(...) instead.", true)]
		public object? findLast() => throw new NotSupportedException("Use .LastOrDefault(...) instead.");

		[Obsolete("Use .Select((x, i) => (x, i)).LastOrDefault(...) instead.", true)]
		public object? findLastIndex() => throw new NotSupportedException("Use .Select((x, i) => (x, i)).LastOrDefault(...) instead.");

		[Obsolete("Use foreach (var x in array) instead.", true)]
		public object? forEach() => throw new NotSupportedException("Use foreach (var x in array) instead.");

		public bool includes(TValue searchElement) =>
			Method<bool>().Invoke(searchElement);

		public bool includes(TValue searchElement, int fromIndex) =>
			Method<bool>().Invoke(searchElement, fromIndex);

		public bool Contains(TValue value) => includes(value);

		public int indexOf(TValue searchElement) =>
			Method<int>().Invoke(searchElement);

		public int indexOf(TValue searchElement, int fromIndex) =>
			Method<int>().Invoke(searchElement, fromIndex);

		[Obsolete("Use string.Join(...) instead.", true)]
		public object? join() => throw new NotSupportedException("Use string.Join(...) instead.");

		[Obsolete("Use .Select((_, i) => i) instead.", true)]
		public object? keys() => throw new NotSupportedException("Use .Select((_, i) => i) instead.");

		public int lastIndexOf(TValue searchElement) =>
			Method<int>().Invoke(searchElement);

		public int lastIndexOf(TValue searchElement, int fromIndex) =>
			Method<int>().Invoke(searchElement, fromIndex);

		[Obsolete("Use .Select(...) instead.", true)]
		public object? map() => throw new NotSupportedException("Use .Select(...) instead.");

		[Obsolete("Use .Aggregate(...) instead.", true)]
		public object? reduce() => throw new NotSupportedException("Use .Aggregate(...) instead.");

		[Obsolete("Use .Reverse().Aggregate(...) instead.", true)]
		public object? reduceRight() => throw new NotSupportedException("Use .Reverse().Aggregate(...) instead.");

		public TArray reverse() =>
			Method<TArray>().Invoke();

		public void set(IReadOnlyList<TValue> array) =>
			Method().Invoke(array);

		public void set(IReadOnlyList<TValue> array, int targetOffset) =>
			Method().Invoke(array, targetOffset);

		public void set(TArray array) =>
			Method().Invoke(array);

		public void set(TArray array, int targetOffset) =>
			Method().Invoke(array, targetOffset);

		public TArray slice() =>
			Method<TArray>().Invoke();

		public TArray slice(int start) =>
			Method<TArray>().Invoke(start);

		public TArray slice(int start, int end) =>
			Method<TArray>().Invoke(start, end);

		[Obsolete("Use .Any(...) instead.", true)]
		public object? some() => throw new NotSupportedException("Use .Any(...) instead.");

		public TArray sort() =>
			Method<TArray>().Invoke();

		public TArray sort(Comparison<TValue> compareFn) =>
			Method<TArray>().Invoke(compareFn);

		public TArray subarray() =>
			Method<TArray>().Invoke();

		public TArray subarray(int start) =>
			Method<TArray>().Invoke(start);

		public TArray subarray(int start, int end) =>
			Method<TArray>().Invoke(start, end);

		[Obsolete("Use .GetEnumerator() instead.", true)]
		public object? values() => throw new NotSupportedException("Use .GetEnumerator() instead.");

		public TValue this[int index]
		{
			get => IndexerGet<TValue>(index);
			set => IndexerSet(index, value);
		}

		public TValue this[Index index]
		{
			get => this[index.GetOffset((int)length)];
			set => this[index.GetOffset((int)length)] = value;
		}

		public TArray this[System.Range range] =>
			subarray(AsInt32(range.Start), AsInt32(range.End));

		private static int AsInt32(Index index) =>
			index.IsFromEnd ? -index.Value : index.Value;

		#region IList
		object? IList.this[int index]
		{
			get => this[index];
			set => this[index] = (TValue)(value ?? throw new NullReferenceException());
		}
		bool IList.IsFixedSize => true;
		bool IList.IsReadOnly => false;
		int IList.Add(object? value) => throw new NotSupportedException();
		void IList.Clear() => throw new NotSupportedException();
		bool IList.Contains(object? value) => value is TValue tvalue ? includes(tvalue) : false;
		int IList.IndexOf(object? value) => value is TValue tvalue ? indexOf(tvalue) : -1;
		void IList.Insert(int index, object? value) => throw new NotSupportedException();
		void IList.Remove(object? value) => throw new NotSupportedException();
		void IList.RemoveAt(int index) => throw new NotSupportedException();
		#endregion
		#region ICollection
		int ICollection.Count => (int)length;
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => throw new NotSupportedException();
		void ICollection.CopyTo(Array array, int index) => throw new NotSupportedException();
		#endregion
		#region IEnumerable
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		#endregion
		#region IList<TValue>
		TValue IList<TValue>.this[int index]
		{
			get => this[index];
			set => this[index] = value;
		}
		int IList<TValue>.IndexOf(TValue item) => indexOf(item);
		void IList<TValue>.Insert(int index, TValue item) => throw new NotSupportedException();
		void IList<TValue>.RemoveAt(int index) => throw new NotSupportedException();
		#endregion
		#region ICollection<TValue>
		bool ICollection<TValue>.IsReadOnly => false;
		int ICollection<TValue>.Count => (int)length;
		void ICollection<TValue>.Add(TValue item) => throw new NotSupportedException();
		void ICollection<TValue>.Clear() => throw new NotSupportedException();
		bool ICollection<TValue>.Contains(TValue item) => includes(item);
		void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex) => throw new NotSupportedException();
		bool ICollection<TValue>.Remove(TValue item) => throw new NotSupportedException();
		#endregion
		#region IEnumerable<TValue>
		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();
		#endregion
		#region IReadOnlyList<TValue>
		TValue IReadOnlyList<TValue>.this[int index] => this[index];
		#endregion
		#region IReadOnlyCollection<TValue>
		int IReadOnlyCollection<TValue>.Count => (int)length;
		#endregion
	}

	public abstract class BigIntegerTypedArray<TArray, TValue> : TypedArray, IReadOnlyList<TValue>, IList<TValue>, IList
		where TArray : class
		where TValue : struct
	{
		private static TypeConversionProvider conversion = new();
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static TValue Convert(BigInteger value) => conversion.Convert<BigInteger, TValue>(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static BigInteger Convert(TValue value) => conversion.Convert<TValue, BigInteger>(value);

		private static JsObject Static => window.Instance.GetCached<JsObject>(typeof(TArray).Name);

		public static TArray from(IReadOnlyList<TValue> source) =>
			Static.Method<TArray>().Invoke(source.Select(Convert).ToImmutableArray());

		private static class Cache<T>
		{
			public static readonly ConditionalWeakTable<Func<T, TValue>, Func<T, BigInteger>> from2Callbacks = new();
			public static readonly ConditionalWeakTable<Func<T, int, TValue>, Func<T, int, BigInteger>> from3Callbacks = new();
		}

		public static TArray from<T>(IReadOnlyList<T> source, Func<T, TValue> mapFn) =>
			Static.Method<TArray>().Invoke(source,
				Cache<T>.from2Callbacks.GetValue(mapFn, static _mapFn => x => Convert(_mapFn(x)))
			);

		public static TArray from<T>(IReadOnlyList<T> source, Func<T, int, TValue> mapFn) =>
			Static.Method<TArray>().Invoke(source,
				Cache<T>.from3Callbacks.GetValue(mapFn, static _mapFn => (x, i) => Convert(_mapFn(x, i)))
			);

		public static TArray of(TValue element0) =>
			Static.Method<TArray>().Invoke(Convert(element0));

		public static TArray of(TValue element0, TValue element1) =>
			Static.Method<TArray>().Invoke(Convert(element0), Convert(element1));

		public static TArray of(TValue element0, TValue element1, TValue element2) =>
			Static.Method<TArray>().Invoke(Convert(element0), Convert(element1), Convert(element2));

		public static TArray of(params TValue[] elements) =>
			Static.Method<TArray>().Invoke(args: elements.Select(x => (object?)Convert(x)).ToArray());

		public IEnumerator<TValue> GetEnumerator()
		{
			var iterator = SymbolMethod<Iterator<BigInteger>>("iterator").Invoke();
			while (iterator.MoveNext())
			{
				yield return Convert(iterator.Current);
			}
		}

		public TValue at(int index) =>
			Convert(Method<BigInteger>().Invoke(index));

		public TArray copyWithin(int target, int start) =>
			Method<TArray>().Invoke(target, start);

		public TArray copyWithin(int target, int start, int end) =>
			Method<TArray>().Invoke(target, start, end);

		[Obsolete("Use .Select((x, i) => (x, i)) instead.", true)]
		public object? entries() => throw new NotSupportedException("Use .Select((x, i) => (x, i)) instead.");

		[Obsolete("Use .All() instead.", true)]
		public object? every() => throw new NotSupportedException("Use .All() instead.");

		public TArray fill(TValue value, int start) =>
			Method<TArray>().Invoke(Convert(value), start);

		public TArray fill(TValue value, int start, int end) =>
			Method<TArray>().Invoke(Convert(value), start, end);

		[Obsolete("Use .Where() instead.", true)]
		public object? filter() => throw new NotSupportedException("Use .Where() instead.");

		[Obsolete("Use .FirstOrDefault(...) instead.", true)]
		public object? find() => throw new NotSupportedException("Use .FirstOrDefault(...) instead.");

		[Obsolete("Use .Select((x, i) => (x, i)).FirstOrDefault(...) instead.", true)]
		public object? findIndex() => throw new NotSupportedException("Use .Select((x, i) => (x, i)).FirstOrDefault(...) instead.");

		[Obsolete("Use .LastOrDefault(...) instead.", true)]
		public object? findLast() => throw new NotSupportedException("Use .LastOrDefault(...) instead.");

		[Obsolete("Use .Select((x, i) => (x, i)).LastOrDefault(...) instead.", true)]
		public object? findLastIndex() => throw new NotSupportedException("Use .Select((x, i) => (x, i)).LastOrDefault(...) instead.");

		[Obsolete("Use foreach (var x in array) instead.", true)]
		public object? forEach() => throw new NotSupportedException("Use foreach (var x in array) instead.");

		public bool includes(TValue searchElement) =>
			Method<bool>().Invoke(Convert(searchElement));

		public bool includes(TValue searchElement, int fromIndex) =>
			Method<bool>().Invoke(Convert(searchElement), fromIndex);

		public int indexOf(TValue searchElement) =>
			Method<int>().Invoke(Convert(searchElement));

		public int indexOf(TValue searchElement, int fromIndex) =>
			Method<int>().Invoke(Convert(searchElement), fromIndex);

		[Obsolete("Use string.Join(...) instead.", true)]
		public object? join() => throw new NotSupportedException("Use string.Join(...) instead.");

		[Obsolete("Use .Select((_, i) => i) instead.", true)]
		public object? keys() => throw new NotSupportedException("Use .Select((_, i) => i) instead.");

		public int lastIndexOf(TValue searchElement) =>
			Method<int>().Invoke(Convert(searchElement));

		public int lastIndexOf(TValue searchElement, int fromIndex) =>
			Method<int>().Invoke(Convert(searchElement), fromIndex);

		[Obsolete("Use .Select(...) instead.", true)]
		public object? map() => throw new NotSupportedException("Use .Select(...) instead.");

		[Obsolete("Use .Aggregate(...) instead.", true)]
		public object? reduce() => throw new NotSupportedException("Use .Aggregate(...) instead.");

		[Obsolete("Use .Reverse().Aggregate(...) instead.", true)]
		public object? reduceRight() => throw new NotSupportedException("Use .Reverse().Aggregate(...) instead.");

		public TArray reverse() =>
			Method<TArray>().Invoke();

		public void set(IReadOnlyList<TValue> array) =>
			Method().Invoke(array.Select(Convert).ToImmutableArray());

		public void set(IReadOnlyList<TValue> array, int targetOffset) =>
			Method().Invoke(array.Select(Convert).ToImmutableArray(), targetOffset);

		public void set(TArray array) =>
			Method().Invoke(array);

		public void set(TArray array, int targetOffset) =>
			Method().Invoke(array, targetOffset);

		public TArray slice() =>
			Method<TArray>().Invoke();

		public TArray slice(int start) =>
			Method<TArray>().Invoke(start);

		public TArray slice(int start, int end) =>
			Method<TArray>().Invoke(start, end);

		[Obsolete("Use .Any(...) instead.", true)]
		public object? some() => throw new NotSupportedException("Use .Any(...) instead.");

		public TArray sort() =>
			Method<TArray>().Invoke();

		private static readonly ConditionalWeakTable<Comparison<TValue>, Comparison<BigInteger>> sortCallbacks = new();

		public TArray sort(Comparison<TValue> compareFn) =>
			Method<TArray>().Invoke(
				sortCallbacks.GetValue(compareFn, static _compareFn => (x, y) => _compareFn(Convert(x), Convert(y)))
			);

		public TArray subarray() =>
			Method<TArray>().Invoke();

		public TArray subarray(int start) =>
			Method<TArray>().Invoke(start);

		public TArray subarray(int start, int end) =>
			Method<TArray>().Invoke(start, end);

		[Obsolete("Use .GetEnumerator() instead.", true)]
		public object? values() => throw new NotSupportedException("Use .GetEnumerator() instead.");

		public TValue this[int index]
		{
			get => Convert(IndexerGet<BigInteger>(index));
			set => IndexerSet(index, Convert(value));
		}

		public TValue this[Index index]
		{
			get => this[index.GetOffset((int)length)];
			set => this[index.GetOffset((int)length)] = value;
		}

		public TArray this[System.Range range] =>
			subarray(AsInt32(range.Start), AsInt32(range.End));

		private static int AsInt32(Index index) =>
			index.IsFromEnd ? -index.Value : index.Value;

		#region IList
		object? IList.this[int index]
		{
			get => this[index];
			set => this[index] = (TValue)(value ?? throw new NullReferenceException());
		}
		bool IList.IsFixedSize => true;
		bool IList.IsReadOnly => false;
		int IList.Add(object? value) => throw new NotSupportedException();
		void IList.Clear() => throw new NotSupportedException();
		bool IList.Contains(object? value) => value is TValue tvalue ? includes(tvalue) : false;
		int IList.IndexOf(object? value) => value is TValue tvalue ? indexOf(tvalue) : -1;
		void IList.Insert(int index, object? value) => throw new NotSupportedException();
		void IList.Remove(object? value) => throw new NotSupportedException();
		void IList.RemoveAt(int index) => throw new NotSupportedException();
		#endregion
		#region ICollection
		int ICollection.Count => (int)length;
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => throw new NotSupportedException();
		void ICollection.CopyTo(Array array, int index) => throw new NotSupportedException();
		#endregion
		#region IEnumerable
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		#endregion
		#region IList<TValue>
		TValue IList<TValue>.this[int index]
		{
			get => this[index];
			set => this[index] = value;
		}
		int IList<TValue>.IndexOf(TValue item) => indexOf(item);
		void IList<TValue>.Insert(int index, TValue item) => throw new NotSupportedException();
		void IList<TValue>.RemoveAt(int index) => throw new NotSupportedException();
		#endregion
		#region ICollection<TValue>
		bool ICollection<TValue>.IsReadOnly => false;
		int ICollection<TValue>.Count => (int)length;
		void ICollection<TValue>.Add(TValue item) => throw new NotSupportedException();
		void ICollection<TValue>.Clear() => throw new NotSupportedException();
		bool ICollection<TValue>.Contains(TValue item) => includes(item);
		void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex) => throw new NotSupportedException();
		bool ICollection<TValue>.Remove(TValue item) => throw new NotSupportedException();
		#endregion
		#region IEnumerable<TValue>
		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();
		#endregion
		#region IReadOnlyList<TValue>
		TValue IReadOnlyList<TValue>.this[int index] => this[index];
		#endregion
		#region IReadOnlyCollection<TValue>
		int IReadOnlyCollection<TValue>.Count => (int)length;
		#endregion
	}
}
