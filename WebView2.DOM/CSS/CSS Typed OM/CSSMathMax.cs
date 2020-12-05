using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_math_max.idl

	public class CSSMathMax : CSSMathValue
	{
		protected internal CSSMathMax(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSMathMax(params CSSNumericValue[] values)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(args: values.ToArray<object?>());

		public IReadOnlyList<CSSNumericValue> values => Get<ImmutableList<CSSNumericValue>>();
	}
}
