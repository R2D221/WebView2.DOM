namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_clip_path_element.idl

	public sealed class SVGClipPathElement : SVGGraphicsElement
	{
		private SVGClipPathElement() { }

		public SVGAnimatedEnumeration<SVGUnitType> clipPathUnits =>
			GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
	}
}