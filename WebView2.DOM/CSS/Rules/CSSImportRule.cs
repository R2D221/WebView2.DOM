using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_import_rule.idl

	public class CSSImportRule : CSSRule
	{
		protected internal CSSImportRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Uri href => Get<Uri>();
		public MediaList media => _media ??= Get<MediaList>();
		private MediaList? _media;
		public CSSStyleSheet styleSheet => _styleSheet ??= Get<CSSStyleSheet>();
		private CSSStyleSheet? _styleSheet;
	}
}
