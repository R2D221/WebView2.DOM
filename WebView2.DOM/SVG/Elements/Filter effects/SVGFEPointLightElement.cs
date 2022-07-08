namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_point_light_element.idl

	public sealed class SVGFEPointLightElement : SVGElement
	{
		private SVGFEPointLightElement() { }

		public SVGAnimatedNumber x => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber y => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber z => Get<SVGAnimatedNumber>();
	}
}