using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_keyframe_rule.idl

	public class CSSKeyframeRule : CSSRule
	{
		protected internal CSSKeyframeRule(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string keyText { get => Get<string>(); set => Set(value); }
		public CSSStyleDeclaration style => _style ??= Get<CSSStyleDeclaration>();
		private CSSStyleDeclaration? _style;
	}
}
