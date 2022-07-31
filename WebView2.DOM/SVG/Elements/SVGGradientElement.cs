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

	public abstract partial class SVGGradientElement : SVGElement
	{
		private protected SVGGradientElement() { }

		public SVGAnimatedEnumeration<SVGUnitType> gradientUnits =>
			GetCached<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedTransformList gradientTransform =>
			GetCached<SVGAnimatedTransformList>();
		public SVGAnimatedEnumeration<SVGSpreadMethod> spreadMethod =>
			GetCached<SVGAnimatedEnumeration<SVGSpreadMethod>>();
	}

	public partial class SVGGradientElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}
}