using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_matrix.idl

	public class SVGMatrix : JsObject
	{
		protected internal SVGMatrix(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public double a { get => Get<double>(); set => Set(value); }
		public double b { get => Get<double>(); set => Set(value); }
		public double c { get => Get<double>(); set => Set(value); }
		public double d { get => Get<double>(); set => Set(value); }
		public double e { get => Get<double>(); set => Set(value); }
		public double f { get => Get<double>(); set => Set(value); }

		public SVGMatrix multiply(SVGMatrix secondMatrix) =>
			Method<SVGMatrix>().Invoke(secondMatrix);
		public SVGMatrix inverse() =>
			Method<SVGMatrix>().Invoke();
		public SVGMatrix translate(float x, float y) =>
			Method<SVGMatrix>().Invoke(x, y);
		public SVGMatrix scale(float scaleFactor) =>
			Method<SVGMatrix>().Invoke(scaleFactor);
		public SVGMatrix scaleNonUniform(float scaleFactorX, float scaleFactorY) =>
			Method<SVGMatrix>().Invoke(scaleFactorX, scaleFactorY);
		public SVGMatrix rotate(float angle) =>
			Method<SVGMatrix>().Invoke(angle);
		public SVGMatrix rotateFromVector(float x, float y) =>
			Method<SVGMatrix>().Invoke(x, y);
		public SVGMatrix flipX() =>
			Method<SVGMatrix>().Invoke();
		public SVGMatrix flipY() =>
			Method<SVGMatrix>().Invoke();
		public SVGMatrix skewX(float angle) =>
			Method<SVGMatrix>().Invoke(angle);
		public SVGMatrix skewY(float angle) =>
			Method<SVGMatrix>().Invoke(angle);
	}
}