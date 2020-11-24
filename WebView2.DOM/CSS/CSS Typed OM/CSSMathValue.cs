namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_math_value.idl

	public enum CSSMathOperator
	{
		sum,
		product,
		negate,
		invert,
		min,
		max,
	}

	public class CSSMathValue : CSSNumericValue
	{
		public CSSMathOperator @operator => Get<CSSMathOperator>();
	}
}
