using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;

namespace WebView2.DOM
{
	public static class Flow
	{
		public static object? CSharpStart { get; }
		public static object? JavaScriptStart { get; }
		public static object? CSharpEnd { get; }
		public static object? JavaScriptEnd { get; }
	}

	public sealed record @null()
	{
		public static readonly @null Value = new();
	}

	public sealed partial class BrowsingContext : IDisposable
	{
		#region static
		private static ConditionalWeakTable<IWebView2, BrowsingContext> instances = new();

		internal static void Set(IWebView2 webView, BrowsingContext coordinator)
		{
			_ = instances.Remove(webView);
			instances.Add(webView, coordinator);
		}

		internal static BrowsingContext? For(IWebView2 webView) => instances.TryGetValue(webView, out var coordinator) ? coordinator : null;

		public static BrowsingContext Current =>
			SynchronizationContext.Current switch
			{
				BrowsingSynchronizationContext c => c.BrowsingContext,
				_ => throw new InvalidOperationException(),
			};
		#endregion

		internal readonly IWebView2 webView;
		internal readonly SynchronizationContext uiSyncContext;
		internal readonly BrowsingSynchronizationContext browsingSyncContext;

		internal readonly Channel<(SendOrPostCallback d, object? state)> callbacksChannel =
			Channel.CreateUnbounded<(SendOrPostCallback d, object? state)>(options: new() { SingleReader = true, AllowSynchronousContinuations = true });

		internal ulong NavigationId { get; }
		internal Window Window { get; } = new Window();
		internal _HostObject HostObject { get; }
		internal JsExecutionContext? RunningExecutionContext { get; private set; }

		internal BrowsingContext(IWebView2 coreWebView, ulong navigationId)
		{
			this.webView = coreWebView;
			this.NavigationId = navigationId;

			uiSyncContext = SynchronizationContext.Current ?? throw new InvalidOperationException();
			browsingSyncContext = new BrowsingSynchronizationContext(this);
			HostObject = new _HostObject(this);

			var id = Guid.NewGuid().ToString();
			References2.SetId(Window, id);
		}

		internal JsExecutionContext StartNewExecutionContext()
		{
			if (RunningExecutionContext is not null) { throw new InvalidOperationException(); }

			return RunningExecutionContext = new JsExecutionContext(this);
		}

		internal void EndExecutionContext(JsExecutionContext executionContext)
		{
			if (executionContext != RunningExecutionContext) { throw new InvalidOperationException(); }

			RunningExecutionContext = null;
		}

		public void Dispose()
		{
			RunningExecutionContext?.Dispose();
			browsingSyncContext.Dispose();
		}
	}
}