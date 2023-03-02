using Microsoft.Web.WebView2.Core;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
					if (_handler != null) { webView.CoreWebView2.WebMessageReceived += CoreWebView_WebMessageReceived; }
				}
				remove
				{
					_handler -= value;
					if (_handler == null) { webView.CoreWebView2.WebMessageReceived -= CoreWebView_WebMessageReceived; }
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
					if (_handler != null) { webView.CoreWebView2.WebMessageReceived += CoreWebView_WebMessageReceived; }
				}
				remove
				{
					_handler -= value;
					if (_handler == null) { webView.CoreWebView2.WebMessageReceived -= CoreWebView_WebMessageReceived; }
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

		public static WinFormsEvents DOMContentLoaded(this Microsoft.Web.WebView2.WinForms.WebView2 webView)
		{
			return winFormsEvents.GetValue(webView, _webView => new WinFormsEvents(_webView));
		}

		public static WpfEvents DOMContentLoaded(this Microsoft.Web.WebView2.Wpf.WebView2 webView)
		{
			return wpfEvents.GetValue(webView, _webView => new WpfEvents(_webView));
		}

		public static async Task InvokeInBrowserContextAsync(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Action<Window> action) =>
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), action);

		public static async Task InvokeInBrowserContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Action<Window> action) =>
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), action);

		private static async Task InvokeInBrowserContextAsync(IWebView2 webView, Action<Window> action)
		{
			var browsingContext = BrowsingContext.For(webView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource();

			browsingContext.browsingSyncContext.Post(
				state: Pool.Box((action, browsingContext.Window, tcs)).Obj,
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
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), function);

		public static async Task<T> InvokeInBrowserContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Window, T> function) =>
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), function);

		private static async Task<T> InvokeInBrowserContextAsync<T>(IWebView2 webView, Func<Window, T> function)
		{
			var browsingContext = BrowsingContext.For(webView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource<T>();

			browsingContext.browsingSyncContext.Post(
				state: Pool.Box((function, browsingContext.Window, tcs)).Obj,
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
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), asyncAction);

		public static async Task InvokeInBrowserContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Window, Task> asyncAction) =>
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), asyncAction);

		private static async Task InvokeInBrowserContextAsync(IWebView2 webView, Func<Window, Task> asyncAction)
		{
			var browsingContext = BrowsingContext.For(webView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource();

			browsingContext.browsingSyncContext.Post(
				state: Pool.Box((asyncAction, browsingContext.Window, tcs)).Obj,
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
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), asyncFunction);

		public static async Task<T> InvokeInBrowserContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Window, Task<T>> asyncFunction) =>
			await InvokeInBrowserContextAsync(Unsafe.As<IWebView2>(webView), asyncFunction);

		private static async Task<T> InvokeInBrowserContextAsync<T>(IWebView2 webView, Func<Window, Task<T>> asyncFunction)
		{
			var browsingContext = BrowsingContext.For(webView);

			if (browsingContext is null) { throw new Exception(); }

			var tcs = new TaskCompletionSource<T>();

			browsingContext.browsingSyncContext.Post(
				state: Pool.Box((asyncFunction, browsingContext.Window, tcs)).Obj,
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
		public static async Task InvokeInWinFormsContextAsync(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Action action)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task InvokeInWpfContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Action action)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Control.BeginInvoke() instead", true)]
		public static async Task<T> InvokeInWinFormsContextAsync<T>(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<T> function)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task<T> InvokeInWpfContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<T> function)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Control.BeginInvoke() instead", true)]
		public static async Task InvokeInWinFormsContextAsync(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<Task> asyncAction)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task InvokeInWpfContextAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Task> asyncAction)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Control.BeginInvoke() instead", true)]
		public static async Task<T> InvokeInWinFormsContextAsync<T>(this Microsoft.Web.WebView2.WinForms.WebView2 webView, Func<Task<T>> asyncFunction)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}

		[Obsolete("Use Dispatcher.InvokeAsync() instead", true)]
		public static async Task<T> InvokeInWpfContextAsync<T>(this Microsoft.Web.WebView2.Wpf.WebView2 webView, Func<Task<T>> asyncFunction)
		{
			await Task.CompletedTask;
			throw new NotSupportedException();
		}
	}
}
