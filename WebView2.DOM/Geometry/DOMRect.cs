using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect.idl

	public class DOMRect : DOMRectReadOnly
	{
		protected internal DOMRect(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public new double x { get => Get<double>(); set => Set(value); }
		public new double y { get => Get<double>(); set => Set(value); }
		public new double width { get => Get<double>(); set => Set(value); }
		public new double height { get => Get<double>(); set => Set(value); }
	}
}
