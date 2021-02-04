using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_view_element.idl

	public partial class SVGViewElement : SVGElement
	{
		protected internal SVGViewElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
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