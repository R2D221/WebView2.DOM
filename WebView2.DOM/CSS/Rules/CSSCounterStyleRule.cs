using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_counter_style_rule.idl

	public class CSSCounterStyleRule : CSSRule
	{
		protected internal CSSCounterStyleRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string name/*	*/=> Get<string>();
		public string system/*	*/=> Get<string>();
		public string symbols/*	*/=> Get<string>();
		public string additiveSymbols/*	*/=> Get<string>();
		public string negative/*	*/=> Get<string>();
		public string prefix/*	*/=> Get<string>();
		public string suffix/*	*/=> Get<string>();
		public string range/*	*/=> Get<string>();
		public string pad/*	*/=> Get<string>();
		public string speakAs/*	*/=> Get<string>();
		public string fallback/*	*/=> Get<string>();
	}
}
