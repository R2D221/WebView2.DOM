using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_import_rule.idl

	public sealed class CSSImportRule : CSSRule
	{
		private CSSImportRule() { }

		public Uri href => Get<Uri>();
		public MediaList media => GetCached<MediaList>();
		public CSSStyleSheet styleSheet => GetCached<CSSStyleSheet>();
	}
}
