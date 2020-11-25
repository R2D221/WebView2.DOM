using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_property_rule.idl

	public class CSSPropertyRule : CSSRule
	{
		protected internal CSSPropertyRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string name => Get<string>();
		public string syntax => Get<string>();
		public bool inherits => Get<bool>();
		public string? initialValue => Get<string?>();
	}
}
