﻿namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_page_rule.idl

	public sealed class CSSPageRule : CSSRule
	{
		private CSSPageRule() { }

		public string selectorText { get => Get<string>(); set => Set(value); }
		public CSSStyleDeclaration style => _style ??= Get<CSSStyleDeclaration>();
		private CSSStyleDeclaration? _style;
	}
}
