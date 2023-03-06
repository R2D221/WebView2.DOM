using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using System.Threading.Tasks;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class BigIntegerTests
	{
		[TestMethod("BigInteger is serialized and deserialized correctly")]
		public async Task BigIntegerIsSerializedAndDeserializedCorrectly()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var newWindow = window.open();

				if (newWindow is null) { Assert.Fail(); throw null!; }

				var tcs = new TaskCompletionSource();

				newWindow.onmessage += (s, e) =>
				{
					try
					{
						var message = (BigInteger)e.data;
						Assert.AreEqual((BigInteger)5, message);
						tcs.SetResult();
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
					finally
					{
						newWindow.close();
					}
				};

				newWindow.postMessage((BigInteger)5);

				await tcs.Task;
			});
		}

		[TestMethod("BigInt64Array gets Int64 values")]
		public async Task BigInt64ArrayGetsInt64Values()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var array = new BigInt64Array(1);
				array[0] = long.MaxValue;
				var value = array[0];

				Assert.AreEqual(long.MaxValue, value);
			});
		}

		[TestMethod("BigInt64Array is sorted correctly")]
		public async Task BigInt64ArrayIsSortedCorrectly()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var array = new BigInt64Array(10);
				array[0] = 0;
				array[1] = 1;
				array[2] = 2;
				array[3] = 3;
				array[4] = 4;
				array[5] = 5;
				array[6] = 6;
				array[7] = 7;
				array[8] = 8;
				array[9] = 9;

				var sorted = array.sort((x, y) => y.CompareTo(x));

				Assert.AreEqual(array[0], 9);
				Assert.AreEqual(array[1], 8);
				Assert.AreEqual(array[2], 7);
				Assert.AreEqual(array[3], 6);
				Assert.AreEqual(array[4], 5);
				Assert.AreEqual(array[5], 4);
				Assert.AreEqual(array[6], 3);
				Assert.AreEqual(array[7], 2);
				Assert.AreEqual(array[8], 1);
				Assert.AreEqual(array[9], 0);
			});
		}
	}
}
