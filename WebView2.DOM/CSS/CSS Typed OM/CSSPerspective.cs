namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_perspective.idl

	public class CSSPerspective : CSSTransformComponent
	{
		public CSSPerspective(CSSNumericValue length) => Construct(length);
		public CSSNumericValue length { get => Get<CSSNumericValue>(); set => Set(value); }
	}
}
