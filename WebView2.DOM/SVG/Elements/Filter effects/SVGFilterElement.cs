namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_filter_element.idl

	public sealed partial class SVGFilterElement : SVGElement
	{
		private SVGFilterElement() { }

		public SVGAnimatedEnumeration<SVGUnitType> filterUnits =>
			Get<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedEnumeration<SVGUnitType> primitiveUnits =>
			Get<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
	}

	public partial class SVGFilterElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}