using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_skew.idl

	public class CSSSkewX : CSSTransformComponent
	{
		protected internal CSSSkewX(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSSkewX(CSSNumericValue ax)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(ax);

		public CSSNumericValue ax { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
