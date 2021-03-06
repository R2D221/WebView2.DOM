using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class FailingTests
	{
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
		public void TypedArrays()
		{
			var a1 = new Float32Array();
			var a2 = new Float64Array();
		}
	}
}
