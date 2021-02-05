using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_number_list.idl

	public class SVGAnimatedNumberList : JsObject
	{
		protected internal SVGAnimatedNumberList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGNumberList baseVal => Get<SVGNumberList>();
		public SVGNumberList animVal => Get<SVGNumberList>();
	}
}