using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using static WebView2.DOM.HTMLElementTag;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public partial class UnitTests
	{
		[TestMethod]
		public async Task T001_RunsNormally()
		{
			var ran = false;

			await webView.RunOnJsThread(window =>
			{
				ran = true;
			});

			Assert.AreEqual(true, ran);
		}

		[TestMethod]
		public async Task T002_ExceptionPropagatesToCaller()
		{
			await Assert.ThrowsExceptionAsync<MyException>(async () =>
			{
				await webView.RunOnJsThread(window =>
				{
					throw new MyException();
				});
			});
		}

		[TestMethod]
		public async Task T003_EnumeratesStyleProperties()
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
	}
}
