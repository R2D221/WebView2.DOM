using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Refactor.WebView2.DOM.Interop;

public sealed class BrowsingContextBridge(
	JsDispatcher dispatcher,
	Channel<(Request, TaskCompletionSource<string?>, JsDispatcherFrame)> requests,
	Action onDOMContentLoaded,
	JsonSerializerOptions jsonOptions,
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
					yield return new RequestWrapper(current, jsonOptions);
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
		(Request, TaskCompletionSource<string?>, JsDispatcherFrame) current,
		JsonSerializerOptions jsonOptions)
	{
		public string Request =>
			// Type is declared as object since we need properties
			// of derived classes to be serialized. This is the
			// accepted solution according to
			// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-polymorphism
			JsonSerializer.Serialize<object>(current.Item1, jsonOptions);

		public void Return(string? json)
		{
			current.Item2.SetResult(json);
			current.Item3.Continue = false;
		}

		public void Throw(string json)
		{
			current.Item2.SetException(JsonSerializer.Deserialize<JsError>(json, jsonOptions)!);
			current.Item3.Continue = false;
		}
	}
}