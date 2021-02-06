using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_distant_light_element.idl

	public class SVGFEDistantLightElement : SVGElement
	{
		protected internal SVGFEDistantLightElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedNumber azimuth => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber elevation => Get<SVGAnimatedNumber>();
	}
}