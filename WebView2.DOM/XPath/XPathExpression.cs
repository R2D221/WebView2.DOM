namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xpath_expression.idl

	public sealed class XPathExpression : JsObject
	{
		private XPathExpression() { }

		public XPathResult evaluate(Node contextNode, XPathResultType type = 0, XPathResult? inResult = null) =>
			Method<XPathResult>().Invoke(contextNode, type, inResult);
	}
}
