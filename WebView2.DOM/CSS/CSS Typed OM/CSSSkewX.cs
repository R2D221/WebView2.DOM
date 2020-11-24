namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_skew.idl

	public class CSSSkewX : CSSTransformComponent
	{
		public CSSSkewX(CSSNumericValue ax) =>
			Construct(ax);

		public CSSNumericValue ax { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
