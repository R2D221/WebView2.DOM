using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Threading;
using static WebView2.DOM.HTMLElementTag;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class UnitTests
	{
		[TestMethod]
		public async Task RunsNormally()
		{
			await wpfSyncContext;

			var ran = false;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				ran = true;
			});

			Assert.AreEqual(true, ran);
		}

		[TestMethod]
		public async Task RunsNormallyAsynchronously()
		{
			await wpfSyncContext;

			var ran = false;

			await webView.InvokeInBrowserContextAsync(async window =>
			{
				await Task.Yield();
				ran = true;
			});

			Assert.AreEqual(true, ran);
		}

		[TestMethod]
		public async Task ValuePropagatesToCaller()
		{
			await wpfSyncContext;

			var value = await webView.InvokeInBrowserContextAsync(window => "foo");

			Assert.AreEqual(value, "foo");
		}

		[TestMethod]
		public async Task ValuePropagatesToCallerAsynchronously()
		{
			await wpfSyncContext;

			var value = await webView.InvokeInBrowserContextAsync(async window =>
			{
				await Task.Yield();
				return "bar";
			});

			Assert.AreEqual(value, "bar");
		}

		[TestMethod]
		public async Task ExceptionPropagatesToCaller()
		{
			await wpfSyncContext;

			_ = await Assert.ThrowsExceptionAsync<MyException>(async () =>
			{
				await webView.InvokeInBrowserContextAsync(window =>
				{
					throw new MyException();
#pragma warning disable CS0162, RCS1134
					// Explicit return so the Action<Window> overload is preferred
					return;
#pragma warning restore CS0162, RCS1134
				});
			});
		}

		[TestMethod]
		public async Task ExceptionPropagatesToCallerAsynchronously()
		{
			await wpfSyncContext;

			_ = await Assert.ThrowsExceptionAsync<MyException>(async () =>
			{
				await webView.InvokeInBrowserContextAsync(async window =>
				{
					await Task.Yield();
					throw new MyException();
				});
			});
		}

		[TestMethod("Exception from callback is handled by the dispatcher")]
		public async Task ExceptionFromCallbackIsHandledByTheDispatcher()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				_ = window.setTimeout(() => throw new MyException(), Duration.Zero);
			});

			var tcs = new TaskCompletionSource();

			application.DispatcherUnhandledException += x;
			void x(object s, DispatcherUnhandledExceptionEventArgs e)
			{
				application.DispatcherUnhandledException -= x;
				e.Handled = true;
				tcs.SetException(e.Exception);
			}

			_ = await Assert.ThrowsExceptionAsync<MyException>(async () =>
			{
				await tcs.Task;
			});
		}

		[TestMethod]
		public async Task CallsUiContext()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(async window =>
			{
				_ = Assert.ThrowsException<InvalidOperationException>(() =>
				{
					var width = mainWindow.Width;
				});

				await webView.InvokeInWpfContextAsync(() =>
				{
					var width = mainWindow.Width;
				});
			});
		}

		[TestMethod]
		public async Task CallsUiContextAndReturnsValue()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var width = await webView.InvokeInWpfContextAsync(() => mainWindow.Width);

				Assert.AreEqual(400, width);
			});
		}

		[TestMethod]
		public async Task CallsUiContextAsynchronously()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(async window =>
			{
				_ = await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
				{
					await Task.Yield();
					var width = mainWindow.Width;
				});

				await webView.InvokeInWpfContextAsync(async () =>
				{
					await Task.Yield();
					var width = mainWindow.Width;
				});
			});
		}

		[TestMethod]
		public async Task CallsUiContextAndReturnsValueAsynchronously()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var width = await webView.InvokeInWpfContextAsync(async () =>
				{
					await Task.Yield();
					return mainWindow.Width;
				});

				Assert.AreEqual(400, width);
			});
		}

		[TestMethod("Object persistent in JS doesn't kill C# reference")]
		public async Task ObjectPersistentInJsDoesntKillCsharpReference()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var weakReference = getWeakReference();
				WeakReference<Document> getWeakReference()
				{
					return new WeakReference<Document>(window.document);
				}

				GC.Collect(0, GCCollectionMode.Forced);
				GC.WaitForPendingFinalizers();

				await Task.Yield();

				var document = window.document;
				Assert.IsInstanceOfType(document, typeof(HTMLDocument));

				var body = document.body;
				Assert.IsInstanceOfType(body, typeof(HTMLBodyElement));
			});
		}

		[TestMethod("Object persistent in C# doesn't kill JS reference")]
		public async Task ObjectPersistentInCsharpDoesntKillJsReference()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var myDiv = window.document.createHTMLElement(div);

				await webView.InvokeInWpfContextAsync(async () =>
				{
					_ = await webView.CoreWebView2.CallDevToolsProtocolMethodAsync("HeapProfiler.collectGarbage", JsonSerializer.Serialize(new { }));
				});

				Assert.AreEqual(window.document, myDiv.ownerDocument);
			});
		}

		[TestMethod]
		public async Task JsIteratorBindsToCSharpEnumerator()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				var children = window.document.children;
				var enumerator = children.GetEnumerator();
				Assert.IsTrue(enumerator.MoveNext());
				Assert.IsInstanceOfType(enumerator.Current, typeof(HTMLHtmlElement));
				Assert.IsFalse(enumerator.MoveNext());
				Assert.IsNull(enumerator.Current);
			});
		}

		[TestMethod]
		public async Task EnumeratesStyleProperties()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				var document = window.document;

				var myDiv = document.createHTMLElement(div);
				_ = document.body.appendChild(myDiv);

				myDiv.style.backgroundColor = "red";
				myDiv.style.width = "10px";
				myDiv.style.height = "10px";

				var styleDict = myDiv.style.ToImmutableDictionary();

				Assert.AreEqual(3, styleDict.Count);
				Assert.AreEqual("red", styleDict["background-color"]);
				Assert.AreEqual("10px", styleDict["width"]);
				Assert.AreEqual("10px", styleDict["height"]);

				myDiv.remove();
			});
		}

		[TestMethod]
		public async Task ComputedStyleMapEnumerationWorksCorrectly()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;

				var styleMap = body.computedStyleMap();
				var styleMapCopy = styleMap.ToImmutableDictionary();
				Assert.AreEqual(styleMap.Count, styleMapCopy.Count);

				var styleMapKeys = styleMap.Keys.ToImmutableHashSet();
				var styleMapCopyKeys = styleMapCopy.Keys.ToImmutableHashSet();

				Assert.IsTrue(styleMapKeys.SetEquals(styleMapCopyKeys));
			});
		}

		[TestMethod]
		public async Task ConstructNewJsObject()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				var styleSheet = new CSSStyleSheet();
				Assert.IsInstanceOfType(styleSheet, typeof(CSSStyleSheet));
				Assert.IsInstanceOfType(styleSheet.cssRules, typeof(CSSRuleList));
			});

			_ = Assert.ThrowsException<InvalidOperationException>(() =>
			{
				// You can't construct a new JS object
				// if you're not in the browser context
				var styleSheet = new CSSStyleSheet();
			});
		}

		[TestMethod]
		public async Task CSSValuesOperations()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				var x = CSS.number(10);
				var y = 6;
				var result = x + y;
				Assert.IsInstanceOfType(result, typeof(CSSUnitValue));
				var unitResult = (CSSUnitValue)result;
				Assert.AreEqual(16, unitResult.value);
				Assert.AreEqual("number", unitResult.unit);
			});
		}

		[TestMethod]
		public async Task CSSUnparsedSegments()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var document = window.document;

				var myDiv = document.createHTMLElement(div);
				myDiv.setAttribute("style", "width: calc(42px + var(--foo, 15em) + var(--bar, var(--far) + 15px))");

				var width = myDiv.attributeStyleMap["width"][0];
				Assert.IsNotNull(width);
				Assert.That.IsInstanceOfType(width, out CSSUnparsedValue unparsedWidth);

				Assert.AreEqual(5, unparsedWidth.Count);

				foreach (var (item, index) in unparsedWidth.Select((x, i) => (x, i)))
				{
					switch (index)
					{
					case 0: Assert.IsInstanceOfType(item.Value, typeof(string/*	*/)); break;
					case 1: Assert.IsInstanceOfType(item.Value, typeof(CSSVariableReferenceValue/*	*/)); break;
					case 2: Assert.IsInstanceOfType(item.Value, typeof(string/*	*/)); break;
					case 3: Assert.IsInstanceOfType(item.Value, typeof(CSSVariableReferenceValue/*	*/)); break;
					case 4: Assert.IsInstanceOfType(item.Value, typeof(string/*	*/)); break;
					}
				}
			});
		}

		[TestMethod]
		public async Task WindowSetTimeout()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var tcs = new TaskCompletionSource<int>();
				var id = window.setTimeout(() => tcs.SetResult(5), Duration.Zero);
				var result = await tcs.Task;
				Assert.AreEqual(5, result);

				var tcs2 = new TaskCompletionSource();
				var id2 = window.setTimeout(str =>
				{
					try
					{
						Assert.AreEqual("test", str);
						tcs2.SetResult();
					}
					catch (Exception ex)
					{
						tcs2.SetException(ex);
					}
				}, Duration.Zero, "test");
				await tcs2.Task;
			});
		}
	}
}
