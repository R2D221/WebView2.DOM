namespace WebView2.DOM
{
	public partial class SVGSVGElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => GetCached<SVGAnimatedRect>();
		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => GetCached<SVGAnimatedPreserveAspectRatio>();
	}
}
