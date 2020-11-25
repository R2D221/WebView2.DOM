using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_condition_rule.idl

	public class CSSConditionRule : CSSGroupingRule
	{
		protected internal CSSConditionRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string conditionText => Get<string>();
	}
}
