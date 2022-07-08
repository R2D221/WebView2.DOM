namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_composite_element.idl

	public enum SVGFECompositeOperator : ushort
	{
		UNKNOWN = 0,
		OVER = 1,
		IN = 2,
		OUT = 3,
		ATOP = 4,
		XOR = 5,
		ARITHMETIC = 6,
	}

	public sealed partial class SVGFECompositeElement : SVGElement
	{
		private SVGFECompositeElement() { }

		public SVGAnimatedString in2 =>
			Get<SVGAnimatedString>();
		public SVGAnimatedString in1 =>
			Get<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGFECompositeOperator> @operator =>
			Get<SVGAnimatedEnumeration<SVGFECompositeOperator>>();
		public SVGAnimatedNumber k1 =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber k2 =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber k3 =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber k4 =>
			Get<SVGAnimatedNumber>();
	}

	public partial class SVGFECompositeElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}