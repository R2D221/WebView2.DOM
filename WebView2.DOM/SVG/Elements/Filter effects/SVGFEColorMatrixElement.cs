namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_color_matrix_element.idl

	public enum SVGFEColorMatrixType : ushort
	{
		UNKNOWN = 0,
		MATRIX = 1,
		SATURATE = 2,
		HUEROTATE = 3,
		LUMINANCETOALPHA = 4,
	}

	public sealed partial class SVGFEColorMatrixElement : SVGElement
	{
		private SVGFEColorMatrixElement() { }

		public SVGAnimatedString in1 =>
			GetCached<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGFEColorMatrixType> type =>
			GetCached<SVGAnimatedEnumeration<SVGFEColorMatrixType>>();
		public SVGAnimatedNumberList values =>
			GetCached<SVGAnimatedNumberList>();
	}

	public partial class SVGFEColorMatrixElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}