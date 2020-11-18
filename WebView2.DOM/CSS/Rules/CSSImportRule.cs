using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_import_rule.idl

	public class CSSImportRule : CSSRule
	{
		public Uri href => Get<Uri>();
		public MediaList media => _media ??= Get<MediaList>();
		private MediaList? _media;
		public CSSStyleSheet styleSheet => _styleSheet ??= Get<CSSStyleSheet>();
		private CSSStyleSheet? _styleSheet;
	}
}
