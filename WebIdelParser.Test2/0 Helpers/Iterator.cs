using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public abstract class Iterator : JsObject { }

	public class Iterator<T> : Iterator, IEnumerator<T>
	{
		private Iterator() { }

		private IteratorItem<T>? current;

		public T Current =>
			current?.done switch
			{
				false => current.value,
				true => throw new InvalidOperationException(),
				null => throw new InvalidOperationException(),
			};

		object? IEnumerator.Current => Current;

		public void Dispose() { }

		public bool MoveNext()
		{
			var current = Method<IteratorItem<T>>("next").Invoke();
			return !current.done;
		}

		public void Reset() => throw new NotSupportedException();
	}

	internal sealed record IteratorItem<T>
	{
		public required T value { get; init; }
		public required bool done { get; init; }
	}
}
