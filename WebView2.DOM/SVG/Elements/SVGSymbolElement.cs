namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_symbol_element.idl

	public sealed partial class SVGSymbolElement : SVGElement
	{
		private SVGSymbolElement() { }
	}

	public partial class SVGSymbolElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => Get<SVGAnimatedRect>();

		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => Get<SVGAnimatedPreserveAspectRatio>();
	}
}