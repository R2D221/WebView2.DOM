using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_angle.idl

	public class SVGAnimatedAngle : JsObject
	{
		protected internal SVGAnimatedAngle(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAngle baseVal => Get<SVGAngle>();
		public SVGAngle animVal => Get<SVGAngle>();
	}
}