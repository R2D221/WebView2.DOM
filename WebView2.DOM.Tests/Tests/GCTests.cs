using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static WebView2.DOM.HTMLElementTag;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class GCTests
	{
		[TestMethod("Object persistent in JS doesn't kill C# reference")]
		public async Task ObjectPersistentInJsDoesntKillCsharpReference()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var weakReference = getWeakReference();
				WeakReference<BarProp> getWeakReference()
				{
					return new WeakReference<BarProp>(window.menubar);
				}

				GC.Collect(0, GCCollectionMode.Forced);
				GC.WaitForPendingFinalizers();

				await Task.Yield();

				Assert.AreEqual(false, weakReference.TryGetTarget(out _));

				var menubar = window.menubar;
				Assert.IsInstanceOfType(menubar, typeof(BarProp));
			});
		}

		[TestMethod("Object persistent in C# doesn't kill JS reference")]
		public async Task ObjectPersistentInCsharpDoesntKillJsReference()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var myDiv = window.document.createHTMLElement(div);

				await await mainWindow.Dispatcher.InvokeAsync(async () =>
				{
					_ = await webView.CoreWebView2.CallDevToolsProtocolMethodAsync("HeapProfiler.collectGarbage", JsonSerializer.Serialize(new { }));
				});

				Assert.AreEqual(window.document, myDiv.ownerDocument);
			});
		}
	}
}
