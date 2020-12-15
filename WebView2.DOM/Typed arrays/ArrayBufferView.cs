using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
#if DEBUG
#error Typed arrays
#endif
	public class ArrayBufferView : JsObject
	{
		protected internal ArrayBufferView(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}