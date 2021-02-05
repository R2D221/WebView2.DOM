using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_rect.idl

	public class SVGAnimatedRect : JsObject
	{
		protected internal SVGAnimatedRect(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGRect baseVal => Get<SVGRect>();
		public SVGRect animVal => Get<SVGRect>();
	}
}