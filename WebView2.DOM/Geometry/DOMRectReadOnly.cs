namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect_read_only.idl

	public class DOMRectReadOnly : JsObject
	{
		public double x => Get<double>();
		public double y => Get<double>();
		public double width => Get<double>();
		public double height => Get<double>();
		public double top => Get<double>();
		public double right => Get<double>();
		public double bottom => Get<double>();
		public double left => Get<double>();
	}
}
