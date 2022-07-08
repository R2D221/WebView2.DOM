namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_length_list.idl

	public sealed class SVGAnimatedLengthList : JsObject
	{
		private SVGAnimatedLengthList() { }

		public SVGLengthList baseVal => Get<SVGLengthList>();
		public SVGLengthList animVal => Get<SVGLengthList>();
	}
}