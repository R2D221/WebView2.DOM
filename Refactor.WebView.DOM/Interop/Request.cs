using System;
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

public sealed class IdWrapper
{
	public object? this[string x] => x switch
	{
		"#type#" => "reference",
		_ => null
	};

	public ulong Id { get; internal set; }
}

public sealed class CallbackWrapper
{
	private readonly BrowsingContext browsingContext;
	private readonly Delegate @delegate;

	internal CallbackWrapper(BrowsingContext browsingContext, Delegate @delegate)
	{
		this.browsingContext = browsingContext;
		this.@delegate = @delegate;
	}

	public object? this[string x] => x switch
	{
		"#type#" => "callback",
		_ => null
	};

	public void Call(object[] args) => browsingContext.Call(@delegate, args);
}

public sealed class ExceptionWrapper(Exception exception)
{
	internal Exception Exception => exception;

	public string name => exception.GetType().Name;

	public string message => exception.Message;

	public ExceptionWrapper? cause => exception.InnerException switch
	{
		Exception ex => new ExceptionWrapper(ex),
		null => null,
	};
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

public sealed class Setter(ulong RefId, string property, object? setValue) : Request("setter", RefId)
{
	public string Property => property;
	public object? SetValue => setValue;
}

public sealed class Invoke(ulong RefId, string method, object?[] args) : Request("invoke", RefId)
{
	public string Method => method;
	public object?[] Args => args;
}

public sealed class ReturnVoid() : Request("return void", 0);

public sealed class Return(object? returnValue) : Request("return", 0)
{
	public object? ReturnValue => returnValue;
}

public sealed class Throw(ExceptionWrapper exception) : Request("throw", 0)
{
	public ExceptionWrapper Exception => exception;
}
