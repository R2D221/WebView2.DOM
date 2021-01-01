using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using static WebView2.DOM.HTMLElementTag;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public partial class UnitTests
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

			await Assert.ThrowsExceptionAsync<MyException>(async () =>
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

			await Assert.ThrowsExceptionAsync<MyException>(async () =>
			{
				await webView.InvokeInBrowserContextAsync(async window =>
				{
					await Task.Yield();
					throw new MyException();
				});
			});
		}

		[TestMethod]
		public async Task CallsUiContext()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(async window =>
			{
				Assert.ThrowsException<InvalidOperationException>(() =>
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
				await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
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
				document.body.appendChild(myDiv);

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
				var styleMapEnumerableCount = styleMap.Count();
				Assert.AreEqual(styleMap.size, (uint)styleMapEnumerableCount);
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

			Assert.ThrowsException<InvalidOperationException>(() =>
			{
				// You can't construct a new JS object
				// if you're not in the JS thread
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

				var width = myDiv.attributeStyleMap.get("width")!;
				Assert.IsNotNull(width);
				Assert.IsInstanceOfType(width, typeof(CSSUnparsedValue));

				var unparsedWidth = (CSSUnparsedValue)width;

				Assert.AreEqual<uint>(5, unparsedWidth.length);

				unparsedWidth[0].Switch(
					(string/*	*/ x) => Assert.IsInstanceOfType(x, typeof(string)),
					(CSSVariableReferenceValue/*	*/ x) => Assert.IsInstanceOfType(x, typeof(string))
				);

				unparsedWidth[1].Switch(
					(string/*	*/ x) => Assert.IsInstanceOfType(x, typeof(CSSVariableReferenceValue)),
					(CSSVariableReferenceValue/*	*/ x) => Assert.IsInstanceOfType(x, typeof(CSSVariableReferenceValue))
				);

				unparsedWidth[2].Switch(
					(string/*	*/ x) => Assert.IsInstanceOfType(x, typeof(string)),
					(CSSVariableReferenceValue/*	*/ x) => Assert.IsInstanceOfType(x, typeof(string))
				);

				unparsedWidth[3].Switch(
					(string/*	*/ x) => Assert.IsInstanceOfType(x, typeof(CSSVariableReferenceValue)),
					(CSSVariableReferenceValue/*	*/ x) => Assert.IsInstanceOfType(x, typeof(CSSVariableReferenceValue))
				);

				unparsedWidth[4].Switch(
					(string/*	*/ x) => Assert.IsInstanceOfType(x, typeof(string)),
					(CSSVariableReferenceValue/*	*/ x) => Assert.IsInstanceOfType(x, typeof(string))
				);
			});
		}




		[TestMethod]
		public void FileApi()
		{
			var blob = new Blob();
			var file = new File();
		}

		[TestMethod]
		public void FontFaceSet()
		{
			var set = new FontFaceSet();
		}

		[TestMethod]
		public void FormData()
		{
			var fd = new FormData();
		}

		[TestMethod]
		public void TypedArrays()
		{
			var a1 = new Float32Array();
			var a2 = new Float64Array();
		}

		[TestMethod]
		public void Forms()
		{
			throw new NotImplementedException();
			//var f = new HTMLFormElement();
			//var elements = f.elements;
			//foreach (var element in elements)
			//{

			//}

			//var a = f.elements["a"];
			//var b = f.elements["b"];
			//var c = f.elements["c"];

			//var label = new HTMLLabelElement();
			//var control = label.control;
		}

		[TestMethod]
		public async Task Inputs()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				var document = window.document;
				var myButton = document.createHTMLInputElement(InputType.button);
				var xxx = myButton.outerHTML;
				throw new NotImplementedException();
			});
		}
	}
}
