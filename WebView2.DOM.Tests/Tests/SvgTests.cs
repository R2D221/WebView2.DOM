using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using static WebView2.DOM.SVGElementTag;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class SvgTests
	{
		[TestMethod("An empty SVG list can be readonly")]
		public async Task SVGListEmptyReadOnly()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var mySvg = window.document.createSVGElement(svg);
				var myPoly = window.document.createSVGElement(polyline);

				var readonlyList = myPoly.animatedPoints;
				var list = myPoly.points;

				Assert.IsTrue(readonlyList.IsReadOnly);
				Assert.IsFalse(list.IsReadOnly);
			});
		}

		[TestMethod("A non-empty SVG list can be readonly")]
		public async Task SVGListReadOnly()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var mySvg = window.document.createSVGElement(svg);
				var myPoly = window.document.createSVGElement(polyline);

				var readonlyList = myPoly.animatedPoints;
				var list = myPoly.points;

				var p0 = mySvg.createSVGPoint();
				p0.x = 1;
				p0.y = 2;

				var p1 = mySvg.createSVGPoint();
				p1.x = 3;
				p1.y = 4;

				list.Add(p0);
				list.Add(p1);

				Assert.IsTrue(readonlyList.IsReadOnly);
				Assert.IsFalse(list.IsReadOnly);
				
				Assert.AreEqual(1, list[0].x);
				Assert.AreEqual(2, list[0].y);
				Assert.AreEqual(3, list[1].x);
				Assert.AreEqual(4, list[1].y);
			});
		}
	}
}
