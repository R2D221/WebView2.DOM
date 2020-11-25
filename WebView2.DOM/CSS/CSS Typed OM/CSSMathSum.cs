using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_math_sum.idl

	public class CSSMathSum : CSSMathValue
	{
		protected internal CSSMathSum(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSMathSum(params CSSNumericValue[] values)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(args: values.ToArray<object?>());

		public IReadOnlyList<CSSNumericValue> values => Get<ImmutableArray<CSSNumericValue>>();
	}
}
