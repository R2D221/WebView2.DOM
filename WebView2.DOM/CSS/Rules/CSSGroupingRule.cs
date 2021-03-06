﻿using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_grouping_rule.idl

	public class CSSGroupingRule : CSSRule
	{
		protected internal CSSGroupingRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSRuleList cssRules => _cssRules ??= Get<CSSRuleList>();
		private CSSRuleList? _cssRules;
		public uint insertRule(string rule, uint index) => Method<uint>().Invoke(rule, index);
		public void deleteRule(uint index) => Method().Invoke(index);
	}
}
