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
			GetCached<SVGAnimatedEnumeration<SVGFEComponentTransferType>>();
		public SVGAnimatedNumberList tableValues =>
			GetCached<SVGAnimatedNumberList>();
		public SVGAnimatedNumber slope =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber intercept =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber amplitude =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber exponent =>
			GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber offset =>
			GetCached<SVGAnimatedNumber>();
	}
}