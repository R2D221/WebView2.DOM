using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_spot_light_element.idl

	public class SVGFESpotLightElement : SVGElement
	{
		protected internal SVGFESpotLightElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

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