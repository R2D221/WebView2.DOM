using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class GithubTests
	{
		[TestMethod("Issue #13: You can ExecuteScriptAsync within the C# browsing context")]
		public async Task Issue13_Async()
		{
			await wpfSyncContext;
			var scriptId = await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(@"function test() { return 'ok'; }");

			try
			{
				var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

				void DOMContentLoaded(object? s, EventArgs e)
				{
					webView.DOMContentLoaded().Handler -= DOMContentLoaded;
					tcs.SetResult();
				}
				webView.DOMContentLoaded().Handler += DOMContentLoaded;

				webView.NavigateToString("<html></html>");

				await tcs.Task;

				await webView.InvokeInBrowserContextAsync(async window =>
				{
					_ = Assert.ThrowsException<InvalidOperationException>(() =>
					{
						var coreWebView = webView.CoreWebView2;
					});

					window.document.body.innerText = "a";

					_ = await webView.Dispatcher.InvokeAsync(async () =>
					{
						var jsonResult = await webView.CoreWebView2.ExecuteScriptAsync("test()");
						Assert.AreEqual("\"ok\"", jsonResult);
					});

					window.document.body.innerText = "b";

					_ = await webView.Dispatcher.InvokeAsync(async () =>
					{
						var jsonResult = await webView.CoreWebView2.ExecuteScriptAsync("test()");
						Assert.AreEqual("\"ok\"", jsonResult);
					});

					window.document.body.innerText = "";
				});
			}
			finally
			{
				webView.CoreWebView2.RemoveScriptToExecuteOnDocumentCreated(scriptId);
			}
		}
	}
}
