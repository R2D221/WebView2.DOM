namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_skew.idl

	public class CSSSkewY : CSSTransformComponent
	{
		public CSSSkewY(CSSNumericValue ay) =>
			Construct(ay);

		public CSSNumericValue ay { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
