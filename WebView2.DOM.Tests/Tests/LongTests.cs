using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using NodaTime.Extensions;
using System.Diagnostics;
using System.Threading.Tasks;
using static WebView2.DOM.HTMLElementTag;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.AdditionalTests
{
	[TestClass]
	public class LongTests
	{
		[TestMethod("Connection with webview doesn't fail after lots of time")]
		public async Task LongTaskAsync()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(async window =>
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				var st2 = new Stopwatch();
				st2.Start();

				var text = window.document.createTextNode("");
				window.document.body.append(text);

				while (stopwatch.ElapsedDuration() <= Duration.FromHours(1))
				{
					var dummy = window.document.createHTMLElement(div);
					text.data = $"{st2.ElapsedDuration()}";
					st2.Restart();
					await Task.Yield();
				}

				st2.Stop();
				stopwatch.Stop();
			});
		}
	}
}
