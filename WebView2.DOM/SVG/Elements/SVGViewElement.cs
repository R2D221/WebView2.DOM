namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_view_element.idl

	public sealed partial class SVGViewElement : SVGElement
	{
		private SVGViewElement() { }
	}

	public partial class SVGViewElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => Get<SVGAnimatedRect>();
		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => Get<SVGAnimatedPreserveAspectRatio>();
	}

	public partial class SVGViewElement : SVGZoomAndPan
	{
		public SVGZoomAndPanType zoomAndPan
		{
			get => Get<SVGZoomAndPanType>();
			set => Set(value);
		}
	}
}