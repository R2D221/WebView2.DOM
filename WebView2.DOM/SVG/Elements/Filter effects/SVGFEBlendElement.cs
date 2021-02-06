using Microsoft.Web.WebView2.Core;

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
	
	public partial class SVGFEBlendElement : SVGElement
	{
		protected internal SVGFEBlendElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedString in1 => Get<SVGAnimatedString>();
		public SVGAnimatedString in2 => Get<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGFEBlendMode> mode =>
			Get<SVGAnimatedEnumeration<SVGFEBlendMode>>();
	}

	public partial class SVGFEBlendElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}