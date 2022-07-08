namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_scroll_timeline_rule.idl

	public sealed class CSSScrollTimelineRule : CSSRule
	{
		private CSSScrollTimelineRule() { }

		public string name => Get<string>();
		public string source => Get<string>();
		public string orientation => Get<string>();
		public string start => Get<string>();
		public string end => Get<string>();
		public string timeRange => Get<string>();
	}
}
