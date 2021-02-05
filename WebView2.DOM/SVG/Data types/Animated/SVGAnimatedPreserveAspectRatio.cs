using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_preserve_aspect_ratio.idl

	public class SVGAnimatedPreserveAspectRatio : JsObject
	{
		protected internal SVGAnimatedPreserveAspectRatio(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGPreserveAspectRatio baseVal => Get<SVGPreserveAspectRatio>();
		public SVGPreserveAspectRatio animVal => Get<SVGPreserveAspectRatio>();
	}
}