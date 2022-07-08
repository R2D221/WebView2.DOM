namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_spot_light_element.idl

	public sealed class SVGFESpotLightElement : SVGElement
	{
		private SVGFESpotLightElement() { }

		public SVGAnimatedNumber x => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber y => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber z => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber pointsAtX => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber pointsAtY => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber pointsAtZ => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber specularExponent => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber limitingConeAngle => Get<SVGAnimatedNumber>();
	}
}