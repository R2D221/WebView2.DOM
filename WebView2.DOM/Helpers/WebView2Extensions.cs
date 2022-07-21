using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using WebView2.DOM.Helpers;

namespace WebView2.DOM
{
	public static class WebView2Extensions
	{
		internal static readonly ConditionalWeakTable<Microsoft.Web.WebView2.WinForms.WebView2, CoreWebView2>
			winformsWebViews2 = new();

		internal static readonly ConditionalWeakTable<Microsoft.Web.WebView2.Wpf.WebView2, CoreWebView2>
			wpfWebViews2 = new();

		private static readonly ConditionalWeakTable<Microsoft.Web.WebView2.WinForms.WebView2, WinFormsEvents>
			winFormsEvents = new();

		private static readonly ConditionalWeakTable<Microsoft.Web.WebView2.Wpf.WebView2, WpfEvents>
			wpfEvents = new();

		//private static readonly ConditionalWeakTable<CoreWebView2, References>
		//	references = new();

		//private static readonly ConditionalWeakTable<CoreWebView2, Coordinator>
		//	coordinators = new();

		//private static readonly ConditionalWeakTable<CoreWebView2, JsonSerializerOptions>
		//	options = new();

		//private static readonly ConditionalWeakTable<JsonSerializerOptions, CoreWebView2>
		//	optionsToWebViews = new();

		//private static readonly ConditionalWeakTable<CoreWebView2, SynchronizationContext>
		//	syncContexts = new();

		public sealed class WinFormsEvents
		{
			private readonly Microsoft.Web.WebView2.WinForms.WebView2 webView;

			public WinFormsEvents(Microsoft.Web.WebView2.WinForms.WebView2 webView)
			{
				this.webView = webView;
			}

			private EventHandler<EventArgs>? _handler;

			public event EventHandler<EventArgs>? Handler
			{
				add
				{
					_handler += value;
					if (_handler != null) { webView.GetCoreWebView().WebMessageReceived += CoreWebView_WebMessageReceived; }
				}
				remove
				{
					_handler -= value;
					if (_handler == null) { webView.GetCoreWebView().WebMessageReceived -= CoreWebView_WebMessageReceived; }
				}
			}

			private void CoreWebView_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
			{
				if (e.WebMessageAsJson == "\"DOMContentLoaded\"")
				{
					_handler?.Invoke(webView, e);
				}
			}
		}

		public sealed class WpfEvents
		{
			private readonly Microsoft.Web.WebView2.Wpf.WebView2 webView;

			public WpfEvents(Microsoft.Web.WebView2.Wpf.WebView2 webView)
			{
				this.webView = webView;
			}

			private EventHandler<EventArgs>? _handler;

			public event EventHandler<EventArgs>? Handler
			{
				add
				{
					_handler += value;
					if (_handler != null) { webView.GetCoreWebView().WebMessageReceived += CoreWebView_WebMessageReceived; }
				}
				remove
				{
					_handler -= value;
					if (_handler == null) { webView.GetCoreWebView().WebMessageReceived -= CoreWebView_WebMessageReceived; }
				}
			}

			private void CoreWebView_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
			{
				if (e.WebMessageAsJson == "\"DOMContentLoaded\"")
				{
					_handler?.Invoke(webView, e);
				}
			}
		}

		//public static References References(this CoreWebView2 coreWebView)
		//{
		//	return references.GetValue(coreWebView, x => new References(x));
		//}

		//public static Coordinator Coordinator(this CoreWebView2 coreWebView)
		//{
		//	return coordinators.GetValue(coreWebView, x => new Coordinator(x));
		//}

		//public static JsonSerializerOptions Options(this CoreWebView2 coreWebView)
		//{
		//	var result = options.GetValue(coreWebView, _ => );

		//#if NETFRAMEWORK
		//	_ = optionsToWebViews.Remove(result);
		//	optionsToWebViews.Add(result, coreWebView);
		//#else
		//	optionsToWebViews.AddOrUpdate(result, coreWebView);
		//#endif

		//	return result;
		//}

		//public static CoreWebView2 CoreWebView(this JsonSerializerOptions options)
		//{
		//	if (!optionsToWebViews.TryGetValue(options, out var result)) { throw new InvalidOperationException(); }
		//	return result;
		//}

		public static WinFormsEvents DOMContentLoaded(this Microsoft.Web.WebView2.WinForms.WebView2 webView)
		{
			return winFormsEvents.GetValue(webView, _webView => new WinFormsEvents(_webView));
		}

		public static WpfEvents DOMContentLoaded(this Microsoft.Web.WebView2.Wpf.WebView2 webView)
		{
			return wpfEvents.GetValue(webView, _webView => new WpfEvents(_webView));
		}

		public static async Task InvokeInBrowserContextAsync(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Action<Window> action) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(action);

		public static async Task InvokeInBrowserContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Action<Window> action) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(action);

		private static async Task InvokeInBrowserContextAsync(this CoreWebView2 coreWebView, Action<Window> action)
		{
			var browsingContext = BrowsingContext.For(coreWebView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource();

			browsingContext.innerSyncContext.Post(
				state: Pool.Box((action, browsingContext.Window, tcs)),
				d: static obj =>
				{
					var (action, window, tcs) = Pool.UnboxAndReturn<(Action<Window>, Window, TaskCompletionSource)>(obj);

					try
					{
						action(window);
						tcs.SetResult();
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
				});

			await tcs.Task;
		}

		public static async Task<T> InvokeInBrowserContextAsync<T>(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<Window, T> function) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(function);

		public static async Task<T> InvokeInBrowserContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Window, T> function) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(function);

		private static async Task<T> InvokeInBrowserContextAsync<T>(this CoreWebView2 coreWebView, Func<Window, T> function)
		{
			var browsingContext = BrowsingContext.For(coreWebView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource<T>();

			browsingContext.innerSyncContext.Post(
				state: Pool.Box((function, browsingContext.Window, tcs)),
				d: static obj =>
				{
					var (function, window, tcs) = Pool.UnboxAndReturn<(Func<Window, T>, Window, TaskCompletionSource<T>)>(obj);

					try
					{
						var result = function(window);
						tcs.SetResult(result);
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
				});

			return await tcs.Task;
		}

		public static async Task InvokeInBrowserContextAsync(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<Window, Task> asyncAction) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(asyncAction);

		public static async Task InvokeInBrowserContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Window, Task> asyncAction) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(asyncAction);

		private static async Task InvokeInBrowserContextAsync(this CoreWebView2 coreWebView, Func<Window, Task> asyncAction)
		{
			var browsingContext = BrowsingContext.For(coreWebView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource();

			browsingContext.innerSyncContext.Post(
				state: Pool.Box((asyncAction, browsingContext.Window, tcs)),
				d: static async obj =>
				{
					var (asyncAction, window, tcs) = Pool.UnboxAndReturn<(Func<Window, Task>, Window, TaskCompletionSource)>(obj);

					try
					{
						await asyncAction(window);
						tcs.SetResult();
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
				});

			await tcs.Task;
		}

		public static async Task<T> InvokeInBrowserContextAsync<T>(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<Window, Task<T>> asyncFunction) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(asyncFunction);

		public static async Task<T> InvokeInBrowserContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Window, Task<T>> asyncFunction) =>
			await webView.GetCoreWebView().InvokeInBrowserContextAsync(asyncFunction);

		private static async Task<T> InvokeInBrowserContextAsync<T>(this CoreWebView2 coreWebView, Func<Window, Task<T>> asyncFunction)
		{
			var browsingContext = BrowsingContext.For(coreWebView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource<T>();

			browsingContext.innerSyncContext.Post(
				state: Pool.Box((asyncFunction, browsingContext.Window, tcs)),
				d: static async obj =>
				{
					var (asyncFunction, window, tcs) = Pool.UnboxAndReturn<(Func<Window, Task<T>>, Window, TaskCompletionSource<T>)>(obj);

					try
					{
						var result = await asyncFunction(window);
						tcs.SetResult(result);
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
				});

			return await tcs.Task;
		}

		[Obsolete("Use Control.BeginInvoke() instead", true)]
		public static async Task InvokeInWinFormsContextAsync(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Action action) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(action);

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task InvokeInWpfContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Action action) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(action);

		[Obsolete("", true)]
		private static async Task InvokeInUiContextAsync(this CoreWebView2 coreWebView, Action action)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Control.BeginInvoke() instead", true)]
		public static async Task<T> InvokeInWinFormsContextAsync<T>(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<T> function) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(function);

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task<T> InvokeInWpfContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<T> function) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(function);

		[Obsolete("", true)]
		private static async Task<T> InvokeInUiContextAsync<T>(this CoreWebView2 coreWebView, Func<T> function)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Control.BeginInvoke() instead", true)]
		public static async Task InvokeInWinFormsContextAsync(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<Task> asyncAction) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(asyncAction);

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task InvokeInWpfContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Task> asyncAction) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(asyncAction);

		[Obsolete("", true)]
		private static async Task InvokeInUiContextAsync(this CoreWebView2 coreWebView, Func<Task> asyncAction)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Control.BeginInvoke() instead", true)]
		public static async Task<T> InvokeInWinFormsContextAsync<T>(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<Task<T>> asyncFunction) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(asyncFunction);

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task<T> InvokeInWpfContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Task<T>> asyncFunction) =>
			await webView.GetCoreWebView().InvokeInUiContextAsync(asyncFunction);
		
		[Obsolete("", true)]
		private static async Task<T> InvokeInUiContextAsync<T>(this CoreWebView2 coreWebView, Func<Task<T>> asyncFunction)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}








		internal static CoreWebView2 GetCoreWebView(this Microsoft.Web.WebView2.WinForms.WebView2 webView)
		{
			var coreWebView = winformsWebViews2.GetValue(webView, x => x.CoreWebView2);
			//_ = syncContexts.GetValue(coreWebView, _ =>
			//{
			//	var result = SynchronizationContext.Current;
			//	if (result is WindowsFormsSynchronizationContext)
			//	{
			//		return result;
			//	}
			//	else
			//	{
			//		throw new InvalidOperationException();
			//	}
			//});
			return coreWebView;
		}

		internal static CoreWebView2 GetCoreWebView(this Microsoft.Web.WebView2.Wpf.WebView2 webView)
		{
			var coreWebView = wpfWebViews2.GetValue(webView, x => x.CoreWebView2);

			//_ = syncContexts.GetValue(coreWebView, _ =>
			//{
			//	var result = SynchronizationContext.Current;
			//	if (result is DispatcherSynchronizationContext)
			//	{
			//		return result;
			//	}
			//	else
			//	{
			//		throw new InvalidOperationException();
			//	}
			//});

			return coreWebView;
		}

		//internal static SynchronizationContext GetSynchronizationContext(this CoreWebView2 coreWebView) =>
		//	syncContexts.GetValue(coreWebView, _ => throw new InvalidOperationException());

		//internal static void SyncContextPost(this CoreWebView2 coreWebView, SendOrPostCallback d, object? state)
		//{
		//	var syncContext = coreWebView.GetSynchronizationContext();
		//	if (syncContext == SynchronizationContext.Current)
		//	{
		//		f();
		//	}
		//	else
		//	{
		//		syncContext.Post(_ => f(), null);
		//	}

		//	void f()
		//	{
		//		coreWebView.Coordinator().SyncContextPost(d, state);
		//	}
		//}

		public static void AssertCorrectState(this Microsoft.Web.WebView2.Wpf.WebView2 webView)
		{
			var coreWebView = webView.GetCoreWebView();

			var browsingContext = BrowsingContext.For(coreWebView);

			if (browsingContext is null) { throw new Exception(); }

			Trace.Assert(browsingContext.coreWebView == coreWebView, "browsingContext.coreWebView == coreWebView");
			Trace.Assert(browsingContext.uiSyncContext is DispatcherSynchronizationContext, "browsingContext.uiSyncContext is DispatcherSynchronizationContext");
			Trace.Assert(browsingContext.innerSyncContext is not null, "browsingContext.innerSyncContext is not null");

			//Trace.Assert(browsingContext.dispatcherFrame is not null, "browsingContext.dispatcherFrame is not null");
			//Trace.Assert(browsingContext.dispatcherFrame?.Continue == true, "browsingContext.dispatcherFrame?.Continue == true");
			//Trace.Assert(browsingContext.cts.IsCancellationRequested == false, "browsingContext.cts.IsCancellationRequested == false");

			//Trace.Assert(browsingContext.requests?.Reader.Completion.IsCompleted != true);
			//Trace.Assert((browsingContext.requests?.Reader.Count ?? 0) == 0);
			//Trace.Assert(browsingContext.responses?.Reader.Completion.IsCompleted != true);
			//Trace.Assert((browsingContext.responses?.Reader.Count ?? 0) == 0);
		}
	}
}
