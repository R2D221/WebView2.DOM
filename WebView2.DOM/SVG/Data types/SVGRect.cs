using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_rect.idl

	public class SVGRect : JsObject
	{
		protected internal SVGRect(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public float x { get => Get<float>(); set => Set(value); }
		public float y { get => Get<float>(); set => Set(value); }
		public float width { get => Get<float>(); set => Set(value); }
		public float height { get => Get<float>(); set => Set(value); }
	}
}