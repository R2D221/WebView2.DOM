namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_turbulence_element.idl

	public enum SVGTurbulenceType : ushort
	{
		UNKNOWN = 0,
		FRACTALNOISE = 1,
		TURBULENCE = 2,
	}

	public enum SVGStitchType : ushort
	{
		UNKNOWN = 0,
		STITCH = 1,
		NOSTITCH = 2,
	}

	public sealed partial class SVGFETurbulenceElement : SVGElement
	{
		private SVGFETurbulenceElement() { }

		public SVGAnimatedNumber baseFrequencyX =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber baseFrequencyY =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedInteger numOctaves =>
			GetCached<SVGAnimatedInteger>();
		public SVGAnimatedNumber seed =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedEnumeration<SVGStitchType> stitchTiles =>
			GetCached<SVGAnimatedEnumeration<SVGStitchType>>();
		public SVGAnimatedEnumeration<SVGTurbulenceType> type =>
			GetCached<SVGAnimatedEnumeration<SVGTurbulenceType>>();
	}

	public partial class SVGFETurbulenceElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}