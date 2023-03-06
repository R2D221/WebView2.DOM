using System;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Threading;

namespace WebView2.DOM
{
	internal sealed class BrowsingSynchronizationContext : SynchronizationContext, IDisposable
	{
		private readonly Thread thread;

		internal BrowsingContext BrowsingContext { get; private set; }

		public BrowsingSynchronizationContext(BrowsingContext browsingContext)
		{
			this.BrowsingContext = browsingContext;

			this.thread = new Thread(loop) { Name = "WebView2.DOM", IsBackground = true };
			this.thread.SetApartmentState(ApartmentState.STA);
			this.thread.Start();
		}

		private void loop()
		{
			SetSynchronizationContext(this);

			Dispatcher.CurrentDispatcher.UnhandledException += (s, e) =>
			{
				e.Handled = true;
				var ex = e.Exception;
				BrowsingContext.webView.BeginInvoke(() => throw new Exception(message: "Unhandled exception in browsing context.", innerException: ex));
			};

			Dispatcher.Run();
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
			_ = Dispatcher.FromThread(thread).BeginInvoke(() =>
			{
				var x = SynchronizationContext.Current;
				SetSynchronizationContext(this);
				try
				{
					d(state);
				}
				finally
				{
					SetSynchronizationContext(x);
				}
			});
		}

		public void Dispose()
		{
			Dispatcher.FromThread(thread).InvokeShutdown();
		}
	}
}