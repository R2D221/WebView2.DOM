namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect.idl

	public class DOMRect : DOMRectReadOnly
	{
		public new double x { get => Get<double>(); set => Set(value); }
		public new double y { get => Get<double>(); set => Set(value); }
		public new double width { get => Get<double>(); set => Set(value); }
		public new double height { get => Get<double>(); set => Set(value); }
	}
}
