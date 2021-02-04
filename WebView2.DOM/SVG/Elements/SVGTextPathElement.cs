using Microsoft.Web.WebView2.Core;

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

	public partial class SVGTextPathElement : SVGTextContentElement
	{
		protected internal SVGTextPathElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength startOffset =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedEnumeration<SVGTextContentLengthAdjust> method =>
			Get<SVGAnimatedEnumeration<SVGTextContentLengthAdjust>>();
		public SVGAnimatedEnumeration<SVGTextPathSpacingType> spacing =>
			Get<SVGAnimatedEnumeration<SVGTextPathSpacingType>>();
	}

	public partial class SVGTextPathElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}