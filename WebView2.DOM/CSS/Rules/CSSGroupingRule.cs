namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_grouping_rule.idl

	public class CSSGroupingRule : CSSRule
	{
		private protected CSSGroupingRule() { }

		public CSSRuleList cssRules => _cssRules ??= Get<CSSRuleList>();
		private CSSRuleList? _cssRules;
		public uint insertRule(string rule, uint index) => Method<uint>().Invoke(rule, index);
		public void deleteRule(uint index) => Method().Invoke(index);
	}
}
