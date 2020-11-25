using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_rule.idl

	public enum CSSRuleType : ushort
	{
		STYLE_RULE/*	*/= 1,
		CHARSET_RULE/*	*/= 2,
		IMPORT_RULE/*	*/= 3,
		MEDIA_RULE/*	*/= 4,
		FONT_FACE_RULE/*	*/= 5,
		PAGE_RULE/*	*/= 6,
		KEYFRAMES_RULE/*	*/= 7,
		KEYFRAME_RULE/*	*/= 8,
		MARGIN_RULE/*	*/= 9,
		NAMESPACE_RULE/*	*/= 10,
		COUNTER_STYLE_RULE/*	*/= 11,
		SUPPORTS_RULE/*	*/= 12,
	}

	public class CSSRule : JsObject
	{
		protected internal CSSRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSRuleType type => Get<CSSRuleType>();
		public string cssText { get => Get<string>(); set => Set(value); }
		public CSSRule? parentRule => Get<CSSRule?>();
		public CSSStyleSheet? parentStyleSheet => Get<CSSStyleSheet?>();
	}
}
