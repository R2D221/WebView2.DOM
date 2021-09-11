using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_rotate.idl

	public class CSSRotate : CSSTransformComponent
	{
		protected internal CSSRotate(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSRotate(CSSNumericValue angleValue)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(angleValue);
		public CSSRotate(CSSNumericValue x, CSSNumericValue y, CSSNumericValue z, CSSNumericValue angle)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(x, y, z, angle);

		public CSSNumericValue angle { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue x { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue y { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue z { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
