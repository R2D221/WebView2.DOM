namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_displacement_map_element.idl

	public enum SVGChannel : ushort
	{
		UNKNOWN = 0,
		R = 1,
		G = 2,
		B = 3,
		A = 4,
	}

	public sealed partial class SVGFEDisplacementMapElement : SVGElement
	{
		private SVGFEDisplacementMapElement() { }

		public SVGAnimatedString in1 =>
			GetCached<SVGAnimatedString>();
		public SVGAnimatedString in2 =>
			GetCached<SVGAnimatedString>();
		public SVGAnimatedNumber scale =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedEnumeration<SVGChannel> xChannelSelector =>
			GetCached<SVGAnimatedEnumeration<SVGChannel>>();
		public SVGAnimatedEnumeration<SVGChannel> yChannelSelector =>
			GetCached<SVGAnimatedEnumeration<SVGChannel>>();
	}

	public partial class SVGFEDisplacementMapElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}