namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_zoom_and_pan.idl

	public enum SVGZoomAndPanType : ushort
	{
		UNKNOWN = 0,
		DISABLE = 1,
		MAGNIFY = 2,
	}

	public interface SVGZoomAndPan
	{
		SVGZoomAndPanType zoomAndPan { get; set; }
	}
}
