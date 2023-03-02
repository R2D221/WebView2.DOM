using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public abstract class Iterator : JsObject { }

	public class Iterator<T> : Iterator, IEnumerator<T>
	{
		private protected Iterator() { }

		private IteratorItem<T>? current;

		public T Current =>
			current switch
			{
				{ done: false } x => x.value,
				{ done: true } => throw new InvalidOperationException(),
				null => throw new InvalidOperationException(),
			};

		object? IEnumerator.Current => Current;

		public void Dispose() { }

		public bool MoveNext()
		{
			var current = Method<IteratorItem<T>>("next").Invoke();
			this.current = current;
			return !current.done;
		}

		public void Reset() => throw new NotSupportedException();
	}

	internal struct IteratorItem<T>
	{
		public required T value { get; init; }
		public required bool done { get; init; }
	}
}
