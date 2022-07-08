using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_keyword_value.idl

	public class CSSKeywordValue : CSSStyleValue
	{
		protected internal CSSKeywordValue() { }

		public CSSKeywordValue(string keyword) =>
			Construct(keyword);

		public string value { get => Get<string>(); set => Set(value); }
	}
}
