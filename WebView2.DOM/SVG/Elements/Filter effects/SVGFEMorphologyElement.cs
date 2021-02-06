using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_morphology_element.idl
	
	public enum SVGMorphologyOperator : ushort
	{
		UNKNOWN = 0,
		ERODE = 1,
		DILATE = 2,
	}
	
	public partial class SVGFEMorphologyElement : SVGElement
	{
		protected internal SVGFEMorphologyElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedString in1 =>
			Get<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGMorphologyOperator> @operator =>
			Get<SVGAnimatedEnumeration<SVGMorphologyOperator>>();
		public SVGAnimatedNumber radiusX =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber radiusY =>
			Get<SVGAnimatedNumber>();
	}

	public partial class SVGFEMorphologyElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}