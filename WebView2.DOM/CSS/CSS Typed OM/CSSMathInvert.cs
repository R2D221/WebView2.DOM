using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_math_invert.idl

	public class CSSMathInvert : CSSMathValue
	{
		protected internal CSSMathInvert(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSMathInvert(CSSNumericValue value)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(value);

		public CSSNumericValue value => Get<CSSNumericValue>();
	}
}
