using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/screen.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/modules/screen_orientation/screen_screen_orientation.idl

	public class Screen : JsObject
	{
		protected internal Screen(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public int availWidth => Get<int>();
		public int availHeight => Get<int>();
		public int width => Get<int>();
		public int height => Get<int>();
		public uint colorDepth => Get<uint>();
		public uint pixelDepth => Get<uint>();

		// Non-standard
		public int availLeft => Get<int>();
		public int availTop => Get<int>();

		public ScreenOrientation orientation => Get<ScreenOrientation>();
	}
}
