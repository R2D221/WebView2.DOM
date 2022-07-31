namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_distant_light_element.idl

	public sealed class SVGFEDistantLightElement : SVGElement
	{
		private SVGFEDistantLightElement() { }

		public SVGAnimatedNumber azimuth => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber elevation => GetCached<SVGAnimatedNumber>();
	}
}