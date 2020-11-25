using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_namespace_rule.idl

	public class CSSNamespaceRule : CSSRule
	{
		protected internal CSSNamespaceRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string namespaceURI => Get<string>();
		public string prefix => Get<string>();
	}
}
