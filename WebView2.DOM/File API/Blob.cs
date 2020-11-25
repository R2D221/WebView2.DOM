using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
#if DEBUG
#error Incomplete
#endif
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/fileapi/blob.idl

	public class Blob : JsObject
	{
		protected internal Blob(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
