namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_text_path_element.idl

	public enum SVGTextPathMethodType : ushort
	{
		UNKNOWN = 0,
		ALIGN = 1,
		STRETCH = 2,
	}

	public enum SVGTextPathSpacingType : ushort
	{
		UNKNOWN = 0,
		AUTO = 1,
		EXACT = 2,
	}

	public sealed partial class SVGTextPathElement : SVGTextContentElement
	{
		private SVGTextPathElement() { }

		public SVGAnimatedLength startOffset =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedEnumeration<SVGTextContentLengthAdjust> method =>
			GetCached<SVGAnimatedEnumeration<SVGTextContentLengthAdjust>>();
		public SVGAnimatedEnumeration<SVGTextPathSpacingType> spacing =>
			GetCached<SVGAnimatedEnumeration<SVGTextPathSpacingType>>();
	}

	public partial class SVGTextPathElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}
}