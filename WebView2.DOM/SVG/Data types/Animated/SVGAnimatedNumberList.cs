namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_number_list.idl

	public sealed class SVGAnimatedNumberList : JsObject
	{
		private SVGAnimatedNumberList() { }

		public SVGNumberList baseVal => Get<SVGNumberList>();
		public SVGNumberList animVal => Get<SVGNumberList>();
	}
}