using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
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
		public void CSharp9RecordsWorkAsRegularClassesInCSharp8()
		{
			var point = new DOMPointInit
			{
				x = 1,
				y = 2,
				z = 3,
				w = 4,
			};

			// init (InitOnly) works correctly in C# 8
			//point.x = 2;

			Assert.AreEqual(1, point.x);
			Assert.AreEqual(2, point.y);
			Assert.AreEqual(3, point.z);
			Assert.AreEqual(4, point.w);
		}
	}
}
