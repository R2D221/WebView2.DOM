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
	}
}