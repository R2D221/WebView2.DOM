using System;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace WebView2.DOM
{
	internal sealed class BrowsingSynchronizationContext : SynchronizationContext, IDisposable
	{
		private readonly Thread thread;

		private readonly BlockingCollection<(SendOrPostCallback, object?)>
			actions = new();

		internal BrowsingContext BrowsingContext { get; private set; }

		public BrowsingSynchronizationContext(BrowsingContext browsingContext)
		{
			this.BrowsingContext = browsingContext;

			this.thread = new Thread(loop) { Name = "WebView2.DOM", IsBackground = true };
			this.thread.Start();
		}

		private void loop()
		{
			SetSynchronizationContext(this);

			foreach (var item in actions.GetConsumingEnumerable())
			{
				try
				{
					var (action, state) = item;

					action(state);
				}
				catch (Exception ex)
				{
					BrowsingContext.uiSyncContext.Post(ex =>
					{
						ExceptionDispatchInfo
							.Capture((Exception)ex!)
							.Throw();
					}, ex);
				}
			}
		}

		public override void Post(SendOrPostCallback d, object? state)
		{
			var success = BrowsingContext.callbacksChannel.Writer.TryWrite((d, state));

			if (!success) { throw new Exception(); }

			BrowsingContext.uiSyncContext.Post(
				state: BrowsingContext,
				d: static obj =>
				{
					if (obj is not BrowsingContext browsingContext) { throw new Exception(); }

					_ = browsingContext.webView.GetCoreWebView2().ExecuteScriptAsync(
						$@"
						(() => {{
							Coordinator.{nameof(BrowsingContext._HostObject.Run)}();
							WebView2DOM.EventLoop();
						}})()
						");
				});
		}

		internal void PostInternal(SendOrPostCallback d, object? state)
		{
			actions.Add((d, state));
		}

		public void Dispose()
		{
			actions.CompleteAdding();
		}
	}
}