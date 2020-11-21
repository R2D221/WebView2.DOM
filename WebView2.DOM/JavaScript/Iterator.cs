using SmartAnalyzers.CSharpExtensions.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public sealed class Iterator : JsObject { }

	public sealed class Iterator<T> : JsObject, IEnumerator<T>
	{
		public static implicit operator Iterator<T>(Iterator iterator) => new Iterator<T>(iterator);

		internal Iterator(Iterator iterator)
		{
			References.Swap(source: iterator, target: this);
		}

		private T current = default!;

		public T Current => current!;

		object? IEnumerator.Current => Current;

		public void Dispose() { }

		public bool MoveNext()
		{
			var result = Method<IteratorItem<T>>("next").Invoke();
			current = result.value;
			return !result.done;
		}

		public void Reset() => throw new NotSupportedException();
	}

	[InitOnly]
	public sealed class IteratorItem<T>
	{
		public T value { get; set; }
		public bool done { get; set; }
	}
}
