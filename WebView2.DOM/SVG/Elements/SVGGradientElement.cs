using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_gradient_element.idl

	public enum SVGSpreadMethod : ushort
	{
		UNKNOWN = 0,
		PAD = 1,
		REFLECT = 2,
		REPEAT = 3,
	}

	public partial class SVGGradientElement : SVGElement
	{
		protected internal SVGGradientElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedEnumeration<SVGUnitType> gradientUnits =>
			Get<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedTransformList gradientTransform =>
			Get<SVGAnimatedTransformList>();
		public SVGAnimatedEnumeration<SVGSpreadMethod> spreadMethod =>
			Get<SVGAnimatedEnumeration<SVGSpreadMethod>>();
	}

	public partial class SVGGradientElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}