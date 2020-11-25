using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_scale.idl

	public class CSSScale : CSSTransformComponent
	{
		protected internal CSSScale(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSScale(CSSNumericValue x, CSSNumericValue y)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(x, y);
		public CSSScale(CSSNumericValue x, CSSNumericValue y, CSSNumericValue z)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(x, y, z);

		public CSSNumericValue x { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue y { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue z { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
