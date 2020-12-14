using Microsoft.Web.WebView2.Core;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WebView2.DOM
{
	internal class WebViewSynchronizationContext : SynchronizationContext
	{
		private static ConditionalWeakTable<CoreWebView2, WebViewSynchronizationContext> syncContexts = new();

		public static WebViewSynchronizationContext For(CoreWebView2 coreWebView) =>
			syncContexts.GetValue(coreWebView, x => new WebViewSynchronizationContext(x));

		private readonly CoreWebView2 coreWebView;

		private WebViewSynchronizationContext(CoreWebView2 coreWebView) =>
			this.coreWebView = coreWebView;

		public override void Post(SendOrPostCallback d, object? state) =>
			coreWebView.SyncContextPost(d, state);
	}
}
