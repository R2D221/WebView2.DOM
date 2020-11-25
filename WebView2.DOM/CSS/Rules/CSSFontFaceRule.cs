using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_font_face_rule.idl

	public class CSSFontFaceRule : CSSRule
	{
		protected internal CSSFontFaceRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSStyleDeclaration style => Get<CSSStyleDeclaration>();
	}
}
