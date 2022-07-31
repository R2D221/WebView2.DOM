using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_keyframe_rule.idl

	public sealed class CSSKeyframeRule : CSSRule
	{
		private CSSKeyframeRule() { }

		public string keyText { get => Get<string>(); set => Set(value); }
		public CSSStyleDeclaration style => GetCached<CSSStyleDeclaration>();
	}
}
