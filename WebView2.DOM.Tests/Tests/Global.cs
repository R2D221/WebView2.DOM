using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WebView2.DOM.Tests
{
	using WebView2 = Microsoft.Web.WebView2.Wpf.WebView2;

	[TestClass]
	public static class Global
	{
		internal static Task windowTask = default!;
		internal static Application application = default!;
		internal static System.Windows.Window mainWindow = default!;
		internal static WebView2 webView = default!;
		internal static SynchronizationContext wpfSyncContext = default!;

		[AssemblyInitialize]
		public static async Task AssemblyInitialize(TestContext context)
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
				_ = application.Run();
			});
			await tcs.Task;
		}

		[AssemblyCleanup]
		public static async Task AssemblyCleanup()
		{
			await mainWindow.Dispatcher.InvokeAsync(() =>
			{
				mainWindow.Close();
			});
			await windowTask;
		}
	}
}
