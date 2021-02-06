using Microsoft.Web.WebView2.Core;

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

	public partial class SVGFEColorMatrixElement : SVGElement
	{
		protected internal SVGFEColorMatrixElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedString in1 =>
			Get<SVGAnimatedString>();
		public SVGAnimatedEnumeration<SVGFEColorMatrixType> type =>
			Get<SVGAnimatedEnumeration<SVGFEColorMatrixType>>();
		public SVGAnimatedNumberList values =>
			Get<SVGAnimatedNumberList>();
	}

	public partial class SVGFEColorMatrixElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}