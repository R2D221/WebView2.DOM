namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_style_rule.idl

	public sealed class CSSStyleRule : CSSRule
	{
		private CSSStyleRule() { }

		public string selectorText { get => Get<string>(); set => Set(value); }
		public CSSStyleDeclaration style => GetCached<CSSStyleDeclaration>();
		public StylePropertyMap styleMap => GetCached<StylePropertyMap>();
	}
}
