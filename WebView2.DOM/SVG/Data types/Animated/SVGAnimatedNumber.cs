using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_number.idl

	public class SVGAnimatedNumber : JsObject
	{
		protected internal SVGAnimatedNumber(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public float baseVal { get => Get<float>(); set => Set(value); }
		public float animVal => Get<float>();
	}
}