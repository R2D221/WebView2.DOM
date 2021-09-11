using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_translate.idl

	public class CSSTranslate : CSSTransformComponent
	{
		protected internal CSSTranslate(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSTranslate(CSSNumericValue x, CSSNumericValue y)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(x, y);
		public CSSTranslate(CSSNumericValue x, CSSNumericValue y, CSSNumericValue z)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(x, y, z);

		public CSSNumericValue x { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue y { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue z { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
