using System;
using System.Runtime.CompilerServices;

namespace Refactor.WebView2.DOM.Interop;

public sealed class JsReference
{
	private readonly BrowsingContext browsingContext;
	private readonly ulong refId;
	private readonly int threadID = Environment.CurrentManagedThreadId;

	internal JsReference(BrowsingContext browsingContext, ulong refId)
	{
		this.browsingContext = browsingContext;
		this.refId = refId;
	}

	private void ThreadAffinity()
	{
		if (Environment.CurrentManagedThreadId != threadID)
		{
			throw new InvalidOperationException();
		}
	}

	public T Get<T>([CallerMemberName] string? property = null)
	{
		if (property is null) { throw new InvalidOperationException(); }
		ThreadAffinity();

		return browsingContext.Get<T>(refId, property);
	}

	public T GetCached<T>([CallerMemberName] string? property = null) => Get<T>(property);

	public string? Invoke(string a, string b) => throw new NotImplementedException();
}
