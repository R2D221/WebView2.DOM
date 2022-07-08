namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_specular_lighting_element.idl

	public sealed partial class SVGFESpecularLightingElement : SVGElement
	{
		private SVGFESpecularLightingElement() { }

		public SVGAnimatedString in1 => Get<SVGAnimatedString>();
		public SVGAnimatedNumber surfaceScale => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber specularConstant => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber specularExponent => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber kernelUnitLengthX => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber kernelUnitLengthY => Get<SVGAnimatedNumber>();
	}

	public partial class SVGFESpecularLightingElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}