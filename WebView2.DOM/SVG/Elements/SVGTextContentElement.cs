using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_text_content_element.idl

	public enum SVGTextContentLengthAdjust : ushort
	{
		UNKNOWN = 0,
		SPACING = 1,
		SPACINGANDGLYPHS = 2,
	}

	public class SVGTextContentElement : SVGGraphicsElement
	{
		protected internal SVGTextContentElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength textLength =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedEnumeration<SVGTextContentLengthAdjust> lengthAdjust =>
			Get<SVGAnimatedEnumeration<SVGTextContentLengthAdjust>>();

		public int getNumberOfChars() => Method<int>().Invoke();
		public float getComputedTextLength() => Method<float>().Invoke();
		public float getSubStringLength(uint charnum, uint nchars) => Method<float>().Invoke(charnum, nchars);
		public SVGPoint getStartPositionOfChar(uint charnum) => Method<SVGPoint>().Invoke(charnum);
		public SVGPoint getEndPositionOfChar(uint charnum) => Method<SVGPoint>().Invoke(charnum);
		public SVGRect getExtentOfChar(uint charnum) => Method<SVGRect>().Invoke(charnum);
		public float getRotationOfChar(uint charnum) => Method<float>().Invoke(charnum);
		public int getCharNumAtPosition(SVGPoint point) => Method<int>().Invoke(point);
		public void selectSubString(uint charnum, uint nchars) => Method().Invoke(charnum, nchars);
	}
}