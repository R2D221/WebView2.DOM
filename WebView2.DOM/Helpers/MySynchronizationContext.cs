using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	internal class MySynchronizationContext : SynchronizationContext
	{
		private readonly CoreWebView2 coreWebView;
		private readonly Action<Action>? dispatcher;

		public MySynchronizationContext(CoreWebView2 coreWebView, Action<Action>? dispatcher)
		{
			this.coreWebView = coreWebView;
			this.dispatcher = dispatcher;
		}

		public override void Post(SendOrPostCallback d, object? state)
		{
			(dispatcher ?? throw new InvalidOperationException())
				.Invoke(() => _ = coreWebView.Run(_ => d(state)));
		}
	}
}
