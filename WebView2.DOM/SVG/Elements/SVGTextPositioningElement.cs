namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_text_positioning_element.idl

	public abstract class SVGTextPositioningElement : SVGTextContentElement
	{
		private protected SVGTextPositioningElement() { }

		public SVGAnimatedLengthList x => GetCached<SVGAnimatedLengthList>();
		public SVGAnimatedLengthList y => GetCached<SVGAnimatedLengthList>();
		public SVGAnimatedLengthList dx => GetCached<SVGAnimatedLengthList>();
		public SVGAnimatedLengthList dy => GetCached<SVGAnimatedLengthList>();
		public SVGAnimatedNumberList rotate => GetCached<SVGAnimatedNumberList>();
	}
}