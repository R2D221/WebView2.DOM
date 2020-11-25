using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_position_value.idl

	public class CSSPositionValue : CSSStyleValue
	{
		protected internal CSSPositionValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSPositionValue(CSSNumericValue x, CSSNumericValue y)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(x, y);

		public CSSNumericValue x { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue y { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
