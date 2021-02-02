namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fit_to_view_box.idl

	public interface SVGFitToViewBox
	{
		SVGAnimatedRect viewBox { get; }
		SVGAnimatedPreserveAspectRatio preserveAspectRatio { get; }
	}
}
