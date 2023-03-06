using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		private readonly Stack<JsExecutionContext> executionContexts = new();

		internal ulong NavigationId { get; }
		internal Window Window { get; } = new Window();
		internal _HostObject HostObject { get; }
		internal JsExecutionContext RunningExecutionContext => executionContexts.Peek();

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
			var executionContext = new JsExecutionContext(this);
			executionContexts.Push(executionContext);
			return executionContext;
		}

		internal void EndExecutionContext(JsExecutionContext executionContext)
		{
			var pop = executionContexts.Pop();
			Debug.Assert(pop == executionContext);
		}

		public void Dispose()
		{
			while (executionContexts.TryPeek(out var executionContext))
			{
				executionContext.Dispose();
			}

			browsingSyncContext.Dispose();
		}
	}
}