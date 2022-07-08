namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_font_face_rule.idl

	public sealed class CSSFontFaceRule : CSSRule
	{
		private CSSFontFaceRule() { }

		public CSSStyleDeclaration style => Get<CSSStyleDeclaration>();
	}
}
