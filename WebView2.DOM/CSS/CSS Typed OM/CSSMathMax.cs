﻿using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_math_max.idl

	public class CSSMathMax : CSSMathValue
	{
		protected internal CSSMathMax() { }

		public CSSMathMax(params CSSNumericValue[] values) =>
			Construct(args: values);

		public IReadOnlyList<CSSNumericValue> values => Get<ImmutableArray<CSSNumericValue>>();
	}
}
