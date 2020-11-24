namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_translate.idl

	public class CSSTranslate : CSSTransformComponent
	{
		public CSSTranslate(CSSNumericValue x, CSSNumericValue y) =>
			Construct(x, y);
		public CSSTranslate(CSSNumericValue x, CSSNumericValue y, CSSNumericValue z) =>
			Construct(x, y, z);

		public CSSNumericValue x { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue y { get => Get<CSSNumericValue>(); set => Set(value); }
		public CSSNumericValue z { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
