using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;

namespace Refactor.WebView2.DOM.Interop;

public sealed class JsDispatcherFrame
{
	private readonly JsDispatcher dispatcher = JsDispatcher.Current;
	private bool @continue = true;

	public bool Continue
	{
		get => @continue;
		set
		{
			@continue = value;
			if (value is false)
			{
				dispatcher.Enqueue(() => { });
			}
		}
	}
}

public sealed class JsDispatcher
{
	private static readonly ThreadLocal<JsDispatcher> threadLocal = new();

	private readonly Thread thread;
	private readonly Channel<Action> actions = Channel.CreateUnbounded<Action>(options: new() { SingleReader = true, AllowSynchronousContinuations = true });

	public JsDispatcher()
	{
		thread = new Thread(Loop) { Name = "WebView2.DOM" };
		thread.Start();
	}

	private void Loop()
	{
		threadLocal.Value = this;
		PushFrame(new());
	}

	public static JsDispatcher Current => threadLocal.Value ?? throw new Exception();

	public void PushFrame(JsDispatcherFrame frame)
	{
		if (frame.Continue is false) { return; }

		while (actions.Reader.WaitToRead())
		{
			if (frame.Continue is false) { return; }
			while (actions.Reader.TryRead(out var action))
			{
				action();
				if (frame.Continue is false) { return; }
			}
		}
	}

	public void Enqueue(Action action)
	{
		var result = actions.Writer.TryWrite(action);
		Debug.Assert(result is true);
	}
}
