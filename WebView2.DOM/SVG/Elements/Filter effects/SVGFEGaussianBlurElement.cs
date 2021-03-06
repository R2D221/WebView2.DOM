﻿using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_gaussian_blur_element.idl

	public partial class SVGFEGaussianBlurElement : SVGElement
	{
		protected internal SVGFEGaussianBlurElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedString in1 => Get<SVGAnimatedString>();
		public SVGAnimatedNumber stdDeviationX => Get<SVGAnimatedNumber>();
		public SVGAnimatedNumber stdDeviationY => Get<SVGAnimatedNumber>();

		public void setStdDeviation(float stdDeviationX, float stdDeviationY) =>
			Method().Invoke(stdDeviationX, stdDeviationY);
	}

	public partial class SVGFEGaussianBlurElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}