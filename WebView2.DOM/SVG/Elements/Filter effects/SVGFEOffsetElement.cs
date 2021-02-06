using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_offset_element.idl

	public partial class SVGFEOffsetElement : SVGElement
	{
		protected internal SVGFEOffsetElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedString in1 => Get<SVGAnimatedString>();
		public SVGAnimatedNumber dx => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber dy => Get<SVGAnimatedNumber>();
	}

	public partial class SVGFEOffsetElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}