namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_rotate.idl

	public class CSSRotate : CSSTransformComponent
	{
		public CSSRotate(CSSNumericValue angleValue) =>
			Construct(angleValue);
		public CSSRotate(CSSNumericValue x, CSSNumericValue y, CSSNumericValue z, CSSNumericValue angle) =>
			Construct(x, y, z, angle);

		public CSSNumericValue angle { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue x { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue y { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue z { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
