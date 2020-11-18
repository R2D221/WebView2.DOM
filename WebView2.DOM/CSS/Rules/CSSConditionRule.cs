namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_condition_rule.idl

	public class CSSConditionRule : CSSGroupingRule
	{
		public string conditionText => Get<string>();
	}
}
