using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
#if DEBUG
#error Typed arrays
#endif
	public class Float64Array : ArrayBufferView
	{
		protected internal Float64Array(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}