namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_text_positioning_element.idl

	public abstract class SVGTextPositioningElement : SVGTextContentElement
	{
		private protected SVGTextPositioningElement() { }

		public SVGAnimatedLengthList x => Get<SVGAnimatedLengthList>();
		public SVGAnimatedLengthList y => Get<SVGAnimatedLengthList>();
		public SVGAnimatedLengthList dx => Get<SVGAnimatedLengthList>();
		public SVGAnimatedLengthList dy => Get<SVGAnimatedLengthList>();
		public SVGAnimatedNumberList rotate => Get<SVGAnimatedNumberList>();
	}
}