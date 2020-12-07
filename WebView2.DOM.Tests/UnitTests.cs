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
			var ran = false;

			await webView.RunOnJsThread(window =>
			{
				ran = true;
			});

			Assert.AreEqual(true, ran);
		}

		[TestMethod]
		public async Task ExceptionPropagatesToCaller()
		{
			await Assert.ThrowsExceptionAsync<MyException>(async () =>
			{
				await webView.RunOnJsThread(window =>
				{
					throw new MyException();
#pragma warning disable CS0162
					// Explicit return so the Action<Window> overload is preferred
					return;
#pragma warning restore CS0162
				});
			});
		}

		[TestMethod]
		public async Task ExceptionPropagatesToCallerAsynchronously()
		{
			await Assert.ThrowsExceptionAsync<MyException>(async () =>
			{
				await webView.RunOnJsThread(async window =>
				{
					await Task.Delay(1);
					throw new MyException();
				});
			});
		}

		[TestMethod]
		public async Task JsIteratorBindsToCSharpEnumerator()
		{
			await webView.RunOnJsThread(window =>
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
			await webView.RunOnJsThread(window =>
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
			await webView.RunOnJsThread(window =>
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
			await webView.RunOnJsThread(window =>
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
			await webView.RunOnJsThread(window =>
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
			await webView.RunOnJsThread(window =>
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
	}
}
