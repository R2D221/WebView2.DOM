using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public abstract class Iterator : JsObject { }

	public sealed class Iterator<T> : Iterator, IEnumerator<T>
	{
		private Iterator() { }

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

	//[InitRequired]
	internal sealed record IteratorItem<T>
	{
		public T value { get; init; } = default!;
		public bool done { get; init; }
	}
}
