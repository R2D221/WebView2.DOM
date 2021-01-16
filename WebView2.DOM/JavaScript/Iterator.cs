using Microsoft.Web.WebView2.Core;
using SmartAnalyzers.CSharpExtensions.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public sealed class Iterator : JsObject
	{
		internal Iterator(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}

	public sealed class Iterator<T> : JsObject, IEnumerator<T>
	{
		public static Iterator<T> FromJsObject(JsObject iterator) => new Iterator<T>(iterator);

		internal Iterator(JsObject iterator)
			 : base(iterator.coreWebView, iterator.referenceId)
		{
			References.Update(target: this);
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

	[InitRequired]
	internal sealed record IteratorItem<T>
	{
		public T value { get; init; }
		public bool done { get; init; }
	}
}
