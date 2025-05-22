using System;
using System.Threading;
using System.Threading.Channels;

namespace Refactor.WebView2.DOM.Interop;

public sealed class JsThread
{
	private readonly Thread thread;
	private readonly Channel<Action> actions = Channel.CreateUnbounded<Action>();

	public JsThread()
	{
		thread = new Thread(Loop) { Name = "WebView2.DOM" };
		thread.Start();
	}

	private void Loop()
	{
		while (actions.Reader.WaitToReadAsync() switch
		{
			{ IsCompleted: true } x => x.GetAwaiter().GetResult(),
			{ IsCompleted: false } x => x.AsTask().GetAwaiter().GetResult(),
		})
		{
			while (actions.Reader.TryRead(out var action))
			{
				action();
			}
		}
	}

	public void Enqueue(Action action)
	{
		_ = actions.Writer.TryWrite(action);
	}
}
