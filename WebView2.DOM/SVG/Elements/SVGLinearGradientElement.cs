namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_linear_gradient_element.idl

	public sealed class SVGLinearGradientElement : SVGGradientElement
	{
		private SVGLinearGradientElement() { }

		public SVGAnimatedLength x1 => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y1 => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength x2 => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y2 => GetCached<SVGAnimatedLength>();
	}
}