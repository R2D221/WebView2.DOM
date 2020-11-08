using System.Threading.Tasks;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_style_sheet.idl

	public class CSSStyleSheet : StyleSheet
	{
		public CSSRule? ownerRule => Get<CSSRule?>();
		public CSSRuleList cssRules => _cssRules ??= Get<CSSRuleList>();
		private CSSRuleList? _cssRules;
		public uint insertRule(string rule, uint index = 0) =>
			Method<uint>().Invoke(rule, index);
		public void deleteRule(uint index) =>
			Method().Invoke(index);

		public Task<CSSStyleSheet> replace(string text) => Method<Task<CSSStyleSheet>>().Invoke(text);
		public void replaceSync(string text) => Method().Invoke(text);

		// Non-standard APIs
		//readonly attribute CSSRuleList rules;
		//long addRule(optional string selector = "undefined", optional string style = "undefined", optional uint index);
		//void removeRule(optional uint index = 0);
	}
}
