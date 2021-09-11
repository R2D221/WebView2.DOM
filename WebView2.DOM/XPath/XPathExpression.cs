using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xpath_expression.idl

	public class XPathExpression : JsObject
	{
		protected internal XPathExpression(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public XPathResult evaluate(Node contextNode, XPathResultType type = 0, XPathResult? inResult = null) =>
			Method<XPathResult>().Invoke(contextNode, type, inResult);
	}
}
