namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_stop_element.idl

	public sealed class SVGStopElement : SVGElement
	{
		private SVGStopElement() { }

		public SVGAnimatedNumber offset => Get<SVGAnimatedNumber>();
	}
}