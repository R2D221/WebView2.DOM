using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_keyword_value.idl

	public class CSSKeywordValue : CSSStyleValue
	{
		protected internal CSSKeywordValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSKeywordValue(string keyword)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(keyword);

		public string value { get => Get<string>(); set => Set(value); }
	}
}
