namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_diffuse_lighting_element.idl

	public sealed partial class SVGFEDiffuseLightingElement : SVGElement
	{
		private SVGFEDiffuseLightingElement() { }

		public SVGAnimatedString in1 => GetCached<SVGAnimatedString>();
		public SVGAnimatedNumber surfaceScale => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber diffuseConstant => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber kernelUnitLengthX => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber kernelUnitLengthY => GetCached<SVGAnimatedNumber>();
	}

	public partial class SVGFEDiffuseLightingElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}