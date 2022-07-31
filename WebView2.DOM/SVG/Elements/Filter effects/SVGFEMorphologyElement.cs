namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_morphology_element.idl

	public enum SVGMorphologyOperator : ushort
	{
		UNKNOWN = 0,
		ERODE = 1,
		DILATE = 2,
	}

	public sealed partial class SVGFEMorphologyElement : SVGElement
	{
		private SVGFEMorphologyElement() { }

		public SVGAnimatedString in1 =>
			GetCached<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGMorphologyOperator> @operator =>
			GetCached<SVGAnimatedEnumeration<SVGMorphologyOperator>>();
		public SVGAnimatedNumber radiusX =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber radiusY =>
			GetCached<SVGAnimatedNumber>();
	}

	public partial class SVGFEMorphologyElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}