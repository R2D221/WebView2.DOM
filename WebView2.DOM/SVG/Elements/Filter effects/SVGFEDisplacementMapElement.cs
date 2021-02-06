using Microsoft.Web.WebView2.Core;

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
	
	public partial class SVGFEDisplacementMapElement : SVGElement
	{
		protected internal SVGFEDisplacementMapElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedString in1 =>
			Get<SVGAnimatedString>();
		public SVGAnimatedString in2 =>
			Get<SVGAnimatedString>();
		public SVGAnimatedNumber scale =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedEnumeration<SVGChannel> xChannelSelector =>
			Get<SVGAnimatedEnumeration<SVGChannel>>();
		public SVGAnimatedEnumeration<SVGChannel> yChannelSelector =>
			Get<SVGAnimatedEnumeration<SVGChannel>>();
	}

	public partial class SVGFEDisplacementMapElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}