using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_string.idl

	public class SVGAnimatedString : JsObject
	{
		protected internal SVGAnimatedString(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string baseVal { get => Get<string>(); set => Set(value); }
		public string animVal => Get<string>();
	}
}