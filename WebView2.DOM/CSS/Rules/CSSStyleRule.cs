using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_style_rule.idl

	public class CSSStyleRule : CSSRule
	{
		public string selectorText { get => Get<string>(); set => Set(value); }
		public CSSStyleDeclaration style => _style ??= Get<CSSStyleDeclaration>();
		private CSSStyleDeclaration? _style;
		public StylePropertyMap styleMap => _styleMap ??= Get<StylePropertyMap>();
		private StylePropertyMap? _styleMap;
	}
}
