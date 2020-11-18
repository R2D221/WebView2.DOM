using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_keyframes_rule.idl

	public class CSSKeyframesRule : CSSRule
	{
		public string name => Get<string>();
		public CSSRuleList cssRules => Get<CSSRuleList>();

		public void appendRule(string rule) => Method().Invoke(rule);
		public void deleteRule(string select) => Method().Invoke(select);
		public CSSKeyframeRule? findRule(string select) => Method<CSSKeyframeRule?>().Invoke(select);

		// Non-standard APIs
		//[NotEnumerable] getter CSSKeyframeRule (uint index);
	}
}
