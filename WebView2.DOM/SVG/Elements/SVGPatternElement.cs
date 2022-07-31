namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_pattern_element.idl

	public sealed partial class SVGPatternElement : SVGElement
	{
		private SVGPatternElement() { }

		public SVGAnimatedEnumeration<SVGUnitType> patternUnits => GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedEnumeration<SVGUnitType> patternContentUnits => GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedTransformList patternTransform => GetCached<SVGAnimatedTransformList>();
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
	}

	public partial class SVGPatternElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => GetCached<SVGAnimatedRect>();
		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => GetCached<SVGAnimatedPreserveAspectRatio>();
	}

	public partial class SVGPatternElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}

	public partial class SVGPatternElement : SVGTests
	{
		public SVGStringList requiredExtensions => GetCached<SVGStringList>();
		public SVGStringList systemLanguage => GetCached<SVGStringList>();
	}
}