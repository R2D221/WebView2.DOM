namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_skew.idl

	public class CSSSkew : CSSTransformComponent
	{
		public CSSSkew(CSSNumericValue ax, CSSNumericValue ay) =>
			Construct(ax, ay);

		public CSSNumericValue ax { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue ay { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
