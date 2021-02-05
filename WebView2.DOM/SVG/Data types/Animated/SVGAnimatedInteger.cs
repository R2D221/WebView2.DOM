using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_integer.idl
	public class SVGAnimatedInteger : JsObject
	{
		protected internal SVGAnimatedInteger(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public int baseVal { get => Get<int>(); set => Set(value); }
		public int animVal => Get<int>();
	}
}