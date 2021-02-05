using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_transform_list.idl

	public class SVGAnimatedTransformList : JsObject
	{
		protected internal SVGAnimatedTransformList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGTransformList baseVal => Get<SVGTransformList>();
		public SVGTransformList animVal => Get<SVGTransformList>();
	}
}