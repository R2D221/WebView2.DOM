using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_perspective.idl

	public class CSSPerspective : CSSTransformComponent
	{
		protected internal CSSPerspective(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSPerspective(CSSNumericValue length)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(length);

		public CSSNumericValue length { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
