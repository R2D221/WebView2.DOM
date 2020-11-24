namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_math_negate.idl

	public class CSSMathNegate : CSSMathValue
	{
		public CSSMathNegate(CSSNumericValue value) => Construct(value);

		public CSSNumericValue value => Get<CSSNumericValue>();
	}
}
