namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_spot_light_element.idl

	public sealed class SVGFESpotLightElement : SVGElement
	{
		private SVGFESpotLightElement() { }

		public SVGAnimatedNumber x => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber y => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber z => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber pointsAtX => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber pointsAtY => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber pointsAtZ => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber specularExponent => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber limitingConeAngle => GetCached<SVGAnimatedNumber>();
	}
}