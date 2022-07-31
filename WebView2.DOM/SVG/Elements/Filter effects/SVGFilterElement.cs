namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_filter_element.idl

	public sealed partial class SVGFilterElement : SVGElement
	{
		private SVGFilterElement() { }

		public SVGAnimatedEnumeration<SVGUnitType> filterUnits =>
			GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedEnumeration<SVGUnitType> primitiveUnits =>
			GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
	}

	public partial class SVGFilterElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}
}