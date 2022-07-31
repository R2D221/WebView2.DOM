namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_blend_element.idl

	public enum SVGFEBlendMode : ushort
	{
		UNKNOWN = 0,
		NORMAL = 1,
		MULTIPLY = 2,
		SCREEN = 3,
		DARKEN = 4,
		LIGHTEN = 5,
		OVERLAY = 6,
		COLOR_DODGE = 7,
		COLOR_BURN = 8,
		HARD_LIGHT = 9,
		SOFT_LIGHT = 10,
		DIFFERENCE = 11,
		EXCLUSION = 12,
		HUE = 13,
		SATURATION = 14,
		COLOR = 15,
		LUMINOSITY = 16,
	}

	public sealed partial class SVGFEBlendElement : SVGElement
	{
		private SVGFEBlendElement() { }

		public SVGAnimatedString in1 => GetCached<SVGAnimatedString>();
		public SVGAnimatedString in2 => GetCached<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGFEBlendMode> mode =>
			GetCached<SVGAnimatedEnumeration<SVGFEBlendMode>>();
	}

	public partial class SVGFEBlendElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}