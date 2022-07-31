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
			GetCached<SVGAnimatedString>();
		public SVGAnimatedString in1 =>
			GetCached<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGFECompositeOperator> @operator =>
			GetCached<SVGAnimatedEnumeration<SVGFECompositeOperator>>();
		public SVGAnimatedNumber k1 =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber k2 =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber k3 =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber k4 =>
			GetCached<SVGAnimatedNumber>();
	}

	public partial class SVGFECompositeElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}