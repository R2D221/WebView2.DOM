using Microsoft.Web.WebView2.Core;

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
	
	public partial class SVGFETurbulenceElement : SVGElement
	{
		protected internal SVGFETurbulenceElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedNumber baseFrequencyX =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber baseFrequencyY =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedInteger numOctaves =>
			Get<SVGAnimatedInteger>();
		public SVGAnimatedNumber seed =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedEnumeration<SVGStitchType> stitchTiles =>
			Get<SVGAnimatedEnumeration<SVGStitchType>>();
		public SVGAnimatedEnumeration<SVGTurbulenceType> type =>
			Get<SVGAnimatedEnumeration<SVGTurbulenceType>>();
	}

	public partial class SVGFETurbulenceElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}