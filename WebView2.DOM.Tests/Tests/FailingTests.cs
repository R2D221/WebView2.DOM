using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebView2.DOM.AdditionalTests
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
	}
}
