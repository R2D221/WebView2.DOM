namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_mask_element.idl

	public sealed partial class SVGMaskElement : SVGElement
	{
		private SVGMaskElement() { }

		public SVGAnimatedEnumeration<SVGUnitType> maskUnits =>
			GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedEnumeration<SVGUnitType> maskContentUnits =>
			GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedLength x =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height =>
			GetCached<SVGAnimatedLength>();
	}

	public partial class SVGMaskElement : SVGTests
	{
		public SVGStringList requiredExtensions => GetCached<SVGStringList>();
		public SVGStringList systemLanguage => GetCached<SVGStringList>();
	}
}