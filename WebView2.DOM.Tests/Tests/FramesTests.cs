using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class FramesTests
	{
		[TestMethod("window.frames === window and it represents a collection of frames/iframes")]
		public async Task Frames()
		{
			await wpfSyncContext;

			await webView.InvokeInBrowserContextAsync(window =>
			{
				var iframe1 = window.document.createHTMLElement(HTMLElementTag.iframe);
				var iframe2 = window.document.createHTMLElement(HTMLElementTag.iframe);
				var iframe3 = window.document.createHTMLElement(HTMLElementTag.iframe);

				window.document.body.append(iframe1);
				window.document.body.append(iframe2);
				window.document.body.append(iframe3);

				var frames = window.frames;

				Assert.AreEqual(window, frames);

				foreach (var frame in frames)
				{
					Assert.IsNotNull(frame);
					Assert.IsInstanceOfType(frame, typeof(Window));
					Assert.AreNotEqual(window, frame);
				}

				iframe1.remove();
				iframe2.remove();
				iframe3.remove();
			});
		}
	}
}
