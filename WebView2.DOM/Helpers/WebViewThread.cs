using System;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace WebView2.DOM
{
	internal class WebViewThread
	{
		private readonly BlockingCollection<Action> actions = new(1);
		private readonly Thread thread;
		private readonly SynchronizationContext webViewSyncContext;
		private readonly SynchronizationContext uiSyncContext;

		public WebViewThread(SynchronizationContext webViewSyncContext, SynchronizationContext uiSyncContext)
		{
			this.webViewSyncContext = webViewSyncContext;
			this.uiSyncContext = uiSyncContext;
			thread = new Thread(threadAction) { IsBackground = true/*, Priority = ThreadPriority.Highest*/ };
			thread.Start();
		}

		private void threadAction()
		{
			SynchronizationContext.SetSynchronizationContext(webViewSyncContext);
			foreach (var action in actions.GetConsumingEnumerable())
			{
				try
				{
					action();
				}
				catch (Exception ex)
				{
					uiSyncContext.Post(ex =>
					{
						ExceptionDispatchInfo
							.Capture((Exception)ex!)
							.Throw();
					}, ex);
				}
			}
		}

		public void QueueUserWorkItem(Action action)
		{
			actions.Add(action);
		}
	}
}