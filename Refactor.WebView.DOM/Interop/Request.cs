using System.Collections.Generic;

namespace Refactor.WebView2.DOM.Interop;

public abstract record Request(string Type, ulong RefId);

public sealed record Getter(ulong RefId, string Property) : Request("getter", RefId);

public sealed record Invoke(ulong RefId, string Method, IReadOnlyList<object?> Args) : Request("invoke", RefId);
