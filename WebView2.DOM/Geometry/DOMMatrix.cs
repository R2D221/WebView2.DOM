using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class DOMMatrix : JsObject
	{
		protected internal DOMMatrix(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}

	public class DOMMatrixReadOnly : JsObject
	{
		protected internal DOMMatrixReadOnly(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}
}
