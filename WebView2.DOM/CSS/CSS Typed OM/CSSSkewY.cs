using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_skew.idl

	public class CSSSkewY : CSSTransformComponent
	{
		protected internal CSSSkewY(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSSkewY(CSSNumericValue ay)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(ay);

		public CSSNumericValue ay { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
