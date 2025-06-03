using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Refactor.WebView2.DOM.Interop;

public sealed class BrowsingContextBridge(
	JsDispatcher dispatcher,
	Channel<(Request, TaskCompletionSource<object?>, JsDispatcherFrame)> requests,
	Action onDOMContentLoaded,
	CancellationToken cancellationToken)
{
	public void OnDOMContentLoaded()
	{
		dispatcher.Enqueue(() =>
		{
			try { onDOMContentLoaded(); }
			finally { requests.Writer.Complete(); }
		});
	}

	public IEnumerator<RequestWrapper> GetEnumerator()
	{
		return new WrapperEnumerator(Inner());
		IEnumerator<RequestWrapper> Inner()
		{
			var reader = requests.Reader;

			while (reader.WaitToRead(cancellationToken))
			{
				while (reader.TryRead(out var current))
				{
					yield return new RequestWrapper(current);
				}
			}
		}
	}

	public sealed class WrapperEnumerator(IEnumerator<RequestWrapper> enumerator) : IEnumerator<RequestWrapper>
	{
		public RequestWrapper Current => enumerator.Current;
		object IEnumerator.Current => ((IEnumerator)enumerator).Current;
		public void Dispose() => enumerator.Dispose();
		public bool MoveNext() => enumerator.MoveNext();
		public void Reset() => enumerator.Reset();
	}

	public sealed class RequestWrapper(
		(Request, TaskCompletionSource<object?>, JsDispatcherFrame) current)
	{
		public object Request => current.Item1;

		public void Return(object? value)
		{
			current.Item2.SetResult(value);
			current.Item3.Continue = false;
		}

		public void ReturnVoid()
		{
			current.Item2.SetResult(ValueTuple.Create());
			current.Item3.Continue = false;
		}

		public void Throw(string name, string message)
		{
			current.Item2.SetException(JsError.NewError(name, message));
			current.Item3.Continue = false;
		}
	}
}
