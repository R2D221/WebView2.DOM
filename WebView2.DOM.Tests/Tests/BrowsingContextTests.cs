using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.WebView2.Core;
using System;
using System.Threading.Tasks;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class BrowsingContextTests
	{
		[TestMethod("Setting location.href causes an OperationCancelledException for the rest of the execution.")]
		public async Task LocationHrefAndNext()
		{
			await wpfSyncContext;

			try
			{
				var exampleComTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
				webView.NavigationCompleted += exampleComNavigationCompleted;
				void exampleComNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs args)
				{
					webView.NavigationCompleted -= exampleComNavigationCompleted;
					exampleComTcs.SetResult();
				}

				await webView.InvokeInBrowserContextAsync(window =>
				{
					var location = window.location;

					var href = location.href;

					Assert.AreEqual(new Uri("about:blank"), href);

					location.href = new Uri("http://example.com");

					_ = Assert.ThrowsException<OperationCanceledException>(() =>
					{
						while (true)
						{
							window.alert(location.href.ToString());
						}
					});
				});

				await exampleComTcs.Task;
				Assert.AreEqual(new Uri("http://example.com"), webView.Source);
			}
			finally
			{
				while (webView.Source != new Uri("about:blank"))
				{
					var aboutBlankTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
					webView.NavigationCompleted += aboutBlankNavigationCompleted;
					void aboutBlankNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs args)
					{
						webView.NavigationCompleted -= aboutBlankNavigationCompleted;
						aboutBlankTcs.SetResult();
					}

					webView.NavigateToString("<html></html>");
					await aboutBlankTcs.Task;
				}
			}
		}

		[TestMethod("Setting location.href as the last line of code doesn't throw OperationCancelledException.")]
		public async Task LocationHrefAndStop()
		{
			await wpfSyncContext;

			try
			{
				var exampleComTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
				webView.NavigationCompleted += exampleComNavigationCompleted;
				void exampleComNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs args)
				{
					webView.NavigationCompleted -= exampleComNavigationCompleted;
					exampleComTcs.SetResult();
				}

				await webView.InvokeInBrowserContextAsync(window =>
				{
					var location = window.location;

					var href = location.href;

					Assert.AreEqual(new Uri("about:blank"), href);

					location.href = new Uri("http://example.com");
				});

				await exampleComTcs.Task;
				Assert.AreEqual(new Uri("http://example.com"), webView.Source);
			}
			finally
			{
				while (webView.Source != new Uri("about:blank"))
				{
					var aboutBlankTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
					webView.NavigationCompleted += aboutBlankNavigationCompleted;
					void aboutBlankNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs args)
					{
						webView.NavigationCompleted -= aboutBlankNavigationCompleted;
						aboutBlankTcs.SetResult();
					}

					webView.NavigateToString("<html></html>");
					await aboutBlankTcs.Task;
				}
			}
		}

		[TestMethod("After navigating to a new page, code executes as usual.")]
		public async Task LocationHrefAndNewCallback()
		{
			await wpfSyncContext;

			try
			{
				var exampleComTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
				webView.NavigationCompleted += exampleComNavigationCompleted;
				void exampleComNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs args)
				{
					webView.NavigationCompleted -= exampleComNavigationCompleted;
					exampleComTcs.SetResult();
				}

				await webView.InvokeInBrowserContextAsync(window =>
				{
					var location = window.location;

					var href = location.href;

					Assert.AreEqual(new Uri("about:blank"), href);

					location.href = new Uri("http://example.com");
				});

				await exampleComTcs.Task;
				Assert.AreEqual(new Uri("http://example.com"), webView.Source);

				await webView.InvokeInBrowserContextAsync(window =>
				{
					var location = window.location;

					var href = location.href;

					Assert.AreEqual(new Uri("http://example.com"), href);
				});
			}
			finally
			{
				while (webView.Source != new Uri("about:blank"))
				{
					var aboutBlankTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
					webView.NavigationCompleted += aboutBlankNavigationCompleted;
					void aboutBlankNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs args)
					{
						webView.NavigationCompleted -= aboutBlankNavigationCompleted;
						aboutBlankTcs.SetResult();
					}

					webView.NavigateToString("<html></html>");
					await aboutBlankTcs.Task;
				}
			}
		}
	}
}
