namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_convolve_matrix_element.idl

	public enum SVGEdgeMode : ushort
	{
		UNKNOWN = 0,
		DUPLICATE = 1,
		WRAP = 2,
		NONE = 3,
	}

	public sealed partial class SVGFEConvolveMatrixElement : SVGElement
	{
		private SVGFEConvolveMatrixElement() { }

		public SVGAnimatedString in1 =>
			Get<SVGAnimatedString>();
		public SVGAnimatedInteger orderX =>
			Get<SVGAnimatedInteger>();
		public SVGAnimatedInteger orderY =>
			Get<SVGAnimatedInteger>();
		public SVGAnimatedNumberList kernelMatrix =>
			Get<SVGAnimatedNumberList>();
		public SVGAnimatedNumber divisor =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber bias =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedInteger targetX =>
			Get<SVGAnimatedInteger>();
		public SVGAnimatedInteger targetY =>
			Get<SVGAnimatedInteger>();
		public SVGAnimatedEnumeration<SVGEdgeMode> edgeMode =>
			Get<SVGAnimatedEnumeration<SVGEdgeMode>>();
		public SVGAnimatedNumber kernelUnitLengthX =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber kernelUnitLengthY =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedBoolean preserveAlpha =>
			Get<SVGAnimatedBoolean>();
	}

	public partial class SVGFEConvolveMatrixElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}