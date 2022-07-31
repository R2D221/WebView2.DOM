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
			GetCached<SVGAnimatedString>();
		public SVGAnimatedInteger orderX =>
			GetCached<SVGAnimatedInteger>();
		public SVGAnimatedInteger orderY =>
			GetCached<SVGAnimatedInteger>();
		public SVGAnimatedNumberList kernelMatrix =>
			GetCached<SVGAnimatedNumberList>();
		public SVGAnimatedNumber divisor =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber bias =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedInteger targetX =>
			GetCached<SVGAnimatedInteger>();
		public SVGAnimatedInteger targetY =>
			GetCached<SVGAnimatedInteger>();
		public SVGAnimatedEnumeration<SVGEdgeMode> edgeMode =>
			GetCached<SVGAnimatedEnumeration<SVGEdgeMode>>();
		public SVGAnimatedNumber kernelUnitLengthX =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber kernelUnitLengthY =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedBoolean preserveAlpha =>
			GetCached<SVGAnimatedBoolean>();
	}

	public partial class SVGFEConvolveMatrixElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}