using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WebView2.DOM.Tests
{
	using WebView2 = Microsoft.Web.WebView2.Wpf.WebView2;

	public partial class UnitTests
	{
		private static Task windowTask = default!;
		private static Application application = default!;
		private static System.Windows.Window mainWindow = default!;
		private static WebView2 webView = default!;
		private static SynchronizationContext wpfSyncContext = default!;

		[ClassInitialize]
		public static async Task ClassInitialize(TestContext context)
		{
			var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
			windowTask = Helpers.RunSTATask(() =>
			{
				application = new Application();
				mainWindow = application.MainWindow = new System.Windows.Window
				{
					WindowStartupLocation = WindowStartupLocation.CenterScreen,
					Width = 400,
					Height = 300,
				};
				mainWindow.Loaded += async (s, e) =>
				{
					wpfSyncContext = SynchronizationContext.Current!;
					webView = new WebView2();
					mainWindow.Content = webView;
					await webView.EnsureCoreWebView2Async();
					await WebView2DOM.InitAsync(webView);
					void DOMContentLoaded(object? s, EventArgs e)
					{
						webView.DOMContentLoaded().Handler -= DOMContentLoaded;
						tcs.SetResult();
					}
					webView.DOMContentLoaded().Handler += DOMContentLoaded;
					webView.NavigateToString("<html></html>");
				};
				mainWindow.Show();
				application.Run();
			});
			await tcs.Task;
		}

		[ClassCleanup]
		public static async Task ClassCleanup()
		{
			await mainWindow.Dispatcher.InvokeAsync(() =>
			{
				mainWindow.Close();
			});
			await windowTask;
		}
	}

	public struct SynchronizationContextAwaiter : INotifyCompletion
	{
		// https://thomaslevesque.com/2015/11/11/explicitly-switch-to-the-ui-thread-in-an-async-method/

		private static readonly SendOrPostCallback _postCallback = state => ((Action)state!)();

		private readonly SynchronizationContext _context;
		public SynchronizationContextAwaiter(SynchronizationContext context)
		{
			_context = context;
		}

		public bool IsCompleted => _context == SynchronizationContext.Current;

		public void OnCompleted(Action continuation) => _context.Post(_postCallback, continuation);

		public void GetResult() { }
	}

	public static class SyncContExtensions
	{
		// https://thomaslevesque.com/2015/11/11/explicitly-switch-to-the-ui-thread-in-an-async-method/

		public static SynchronizationContextAwaiter GetAwaiter(this SynchronizationContext context)
		{
			return new SynchronizationContextAwaiter(context);
		}
	}
}
