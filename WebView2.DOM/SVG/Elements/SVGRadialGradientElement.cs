namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_radial_gradient_element.idl

	public sealed class SVGRadialGradientElement : SVGGradientElement
	{
		private SVGRadialGradientElement() { }

		public SVGAnimatedLength cx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength cy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength r => Get<SVGAnimatedLength>();
		public SVGAnimatedLength fx => Get<SVGAnimatedLength>();
		public SVGAnimatedLength fy => Get<SVGAnimatedLength>();
		public SVGAnimatedLength fr => Get<SVGAnimatedLength>();
	}
}