﻿namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xpath_evaluator.idl

	public class XPathEvaluator : JsObject
	{
		public XPathEvaluator() =>
			Construct();

		// https://dom.spec.whatwg.org/#mixin-xpathevaluatorbase
		public XPathExpression createExpression(string expression, XPathNSResolver? resolver = null) =>
			Method<XPathExpression>().Invoke(expression, resolver);

		public XPathNSResolver createNSResolver(Node nodeResolver) =>
			Method<XPathNSResolver>().Invoke(nodeResolver);

		public XPathResult evaluate(string expression, Node contextNode, XPathNSResolver? resolver = null, XPathResultType type = 0, XPathResult? inResult = null) =>
			Method<XPathResult>().Invoke(expression, contextNode, resolver, type, inResult);
	}
}