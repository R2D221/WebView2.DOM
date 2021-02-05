using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_length_list.idl

	public class SVGAnimatedLengthList : JsObject
	{
		protected internal SVGAnimatedLengthList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGLengthList baseVal => Get<SVGLengthList>();
		public SVGLengthList animVal => Get<SVGLengthList>();
	}
}