namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_radial_gradient_element.idl

	public sealed class SVGRadialGradientElement : SVGGradientElement
	{
		private SVGRadialGradientElement() { }

		public SVGAnimatedLength cx => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength cy => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength r => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength fx => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength fy => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength fr => GetCached<SVGAnimatedLength>();
	}
}