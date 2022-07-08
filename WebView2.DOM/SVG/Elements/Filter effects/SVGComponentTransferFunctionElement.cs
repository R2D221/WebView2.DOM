namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_component_transfer_function_element.idl

	public enum SVGFEComponentTransferType : ushort
	{
		UNKNOWN = 0,
		IDENTITY = 1,
		TABLE = 2,
		DISCRETE = 3,
		LINEAR = 4,
		GAMMA = 5,
	}

	public abstract class SVGComponentTransferFunctionElement : SVGElement
	{
		private protected SVGComponentTransferFunctionElement() { }

		public SVGAnimatedEnumeration<SVGFEComponentTransferType> type =>
			Get<SVGAnimatedEnumeration<SVGFEComponentTransferType>>();
		public SVGAnimatedNumberList tableValues =>
			Get<SVGAnimatedNumberList>();
		public SVGAnimatedNumber slope =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber intercept =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber amplitude =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber exponent =>
			Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber offset =>
			Get<SVGAnimatedNumber>();
	}
}