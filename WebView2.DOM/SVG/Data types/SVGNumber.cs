using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_number.idl

	public class SVGNumber : JsObject
	{
		protected internal SVGNumber(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public float value { get => Get<float>(); set => Set(value); }
	}
}