using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_pattern_element.idl

	public partial class SVGPatternElement : SVGElement
	{
		protected internal SVGPatternElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedEnumeration<SVGUnitType> patternUnits => Get<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedEnumeration<SVGUnitType> patternContentUnits => Get<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedTransformList patternTransform => Get<SVGAnimatedTransformList>();
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
	}

	public partial class SVGPatternElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => Get<SVGAnimatedRect>();

		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => Get<SVGAnimatedPreserveAspectRatio>();
	}

	public partial class SVGPatternElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}

	public partial class SVGPatternElement : SVGTests
	{
		public SVGStringList requiredExtensions => Get<SVGStringList>();

		public SVGStringList systemLanguage => Get<SVGStringList>();
	}
}