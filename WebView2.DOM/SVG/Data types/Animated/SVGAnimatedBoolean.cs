using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_boolean.idl

	public class SVGAnimatedBoolean : JsObject
	{
		protected internal SVGAnimatedBoolean(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public bool baseVal { get => Get<bool>(); set => Set(value); }
		public bool animVal => Get<bool>();
	}
}