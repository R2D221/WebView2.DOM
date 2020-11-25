using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_skew.idl

	public class CSSSkew : CSSTransformComponent
	{
		protected internal CSSSkew(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSSkew(CSSNumericValue ax, CSSNumericValue ay)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(ax, ay);

		public CSSNumericValue ax { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue ay { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
