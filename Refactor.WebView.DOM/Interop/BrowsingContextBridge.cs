using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Refactor.WebView2.DOM.Interop;

public sealed class BrowsingContextBridge(
	JsThread thread,
	Channel<(Request, TaskCompletionSource<string?>)> requests,
	Action onDOMContentLoaded,
	JsonSerializerOptions jsonOptions,
	CancellationToken cancellationToken)
{
	public void OnDOMContentLoaded()
	{
		thread.Enqueue(() =>
		{
			try { onDOMContentLoaded(); }
			finally { requests.Writer.Complete(); }
		});
	}

	public IEnumerator<ItemItemItem> GetEnumerator()
	{
		return new WrapperEnumerator(Inner());
		IEnumerator<ItemItemItem> Inner()
		{
			var reader = requests.Reader;

			while (reader.WaitToReadAsync(cancellationToken) switch
			{
				{ IsCompleted: true } x => x.GetAwaiter().GetResult(),
				{ IsCompleted: false } x => x.AsTask().GetAwaiter().GetResult(),
			})
			{
				while (reader.TryRead(out var current))
				{
					yield return new ItemItemItem(current, jsonOptions);
				}
			}
		}
	}

	public sealed class WrapperEnumerator(IEnumerator<ItemItemItem> enumerator) : IEnumerator<ItemItemItem>
	{
		public ItemItemItem Current => enumerator.Current;
		object IEnumerator.Current => ((IEnumerator)enumerator).Current;
		public void Dispose() => enumerator.Dispose();
		public bool MoveNext() => enumerator.MoveNext();
		public void Reset() => enumerator.Reset();
	}

	public sealed class ItemItemItem(
		(Request, TaskCompletionSource<string?>) current,
		JsonSerializerOptions jsonOptions)
	{
		public string Request =>
			// Type is declared as object since we need properties
			// of derived classes to be serialized. This is the
			// accepted solution according to
			// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-polymorphism
			JsonSerializer.Serialize<object>(current.Item1, jsonOptions);

		public void Return(string? json) => current.Item2.SetResult(json);

		public void Throw(string json)
		{
			var exception = JsonSerializer.Deserialize<Exception>(json);
			current.Item2.SetException(exception!);
		}
	}
}