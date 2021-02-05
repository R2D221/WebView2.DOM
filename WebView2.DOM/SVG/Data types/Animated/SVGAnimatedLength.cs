using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_length.idl

	public class SVGAnimatedLength : JsObject
	{
		protected internal SVGAnimatedLength(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGLength baseVal => Get<SVGLength>();
		public SVGLength animVal => Get<SVGLength>();
	}
}