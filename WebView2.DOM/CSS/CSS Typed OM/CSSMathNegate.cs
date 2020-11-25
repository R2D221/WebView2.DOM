using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_math_negate.idl

	public class CSSMathNegate : CSSMathValue
	{
		protected internal CSSMathNegate(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSMathNegate(CSSNumericValue value)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(value);

		public CSSNumericValue value => Get<CSSNumericValue>();
	}
}
