using System.Collections.Generic;

namespace Refactor.WebView2.DOM.Interop;

public sealed class PlainObjectWrapper
{
	private readonly Dictionary<string, object?> dict = new();

	public object? this[string x]
	{
		get => dict.TryGetValue(x, out var result) ? result : null;
		set => dict[x] = value;
	}
}

public abstract class Request(string type, ulong refId)
{
	public string Type => type;
	public ulong RefId => refId;
}

public sealed class Getter(ulong RefId, string property) : Request("getter", RefId)
{
	public string Property => property;
}

public sealed class Invoke(ulong RefId, string method, object?[] args) : Request("invoke", RefId)
{
	public string Method => method;
	public object?[] Args => args;
}
