namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_a_element.idl

	public sealed partial class SVGAElement : SVGGraphicsElement
	{
		private SVGAElement() { }

		public SVGAnimatedString target => Get<SVGAnimatedString>();
	}
}