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

	internal ulong Id => refId;

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

	internal Invoker<ValueTuple> Method([CallerMemberName] string method = "") => new(this, method);
	internal Invoker<T> Method<T>([CallerMemberName] string method = "") => new(this, method);

	internal readonly ref struct Invoker<T>(JsReference @this, string method)
	{
		internal T Invoke(params ReadOnlySpan<object?> @params)
		{
			return @this.browsingContext.Invoke<T>(@this.refId, method, @params);
		}
	}
}
