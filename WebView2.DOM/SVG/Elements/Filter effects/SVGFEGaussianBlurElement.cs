namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_gaussian_blur_element.idl

	public sealed partial class SVGFEGaussianBlurElement : SVGElement
	{
		private SVGFEGaussianBlurElement() { }

		public SVGAnimatedString in1 => GetCached<SVGAnimatedString>();
		public SVGAnimatedNumber stdDeviationX => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber stdDeviationY => GetCached<SVGAnimatedNumber>();

		public void setStdDeviation(float stdDeviationX, float stdDeviationY) =>
			Method().Invoke(stdDeviationX, stdDeviationY);
	}

	public partial class SVGFEGaussianBlurElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}