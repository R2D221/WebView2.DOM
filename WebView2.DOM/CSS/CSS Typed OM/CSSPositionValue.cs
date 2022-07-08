using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_position_value.idl

	public class CSSPositionValue : CSSStyleValue
	{
		protected internal CSSPositionValue() { }

		public CSSPositionValue(CSSNumericValue x, CSSNumericValue y) =>
			Construct(x, y);

		public CSSNumericValue x { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue y { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
