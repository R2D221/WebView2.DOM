namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_property_rule.idl

	public sealed class CSSPropertyRule : CSSRule
	{
		private CSSPropertyRule() { }

		public string name => Get<string>();
		public string syntax => Get<string>();
		public bool inherits => Get<bool>();
		public string? initialValue => Get<string?>();
	}
}
