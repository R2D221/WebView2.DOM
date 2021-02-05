using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_point.idl

	public class SVGPoint : JsObject
	{
		protected internal SVGPoint(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public float x { get => Get<float>(); set => Set(value); }
		public float y { get => Get<float>(); set => Set(value); }

		public SVGPoint matrixTransform(SVGMatrix matrix) =>
			Method<SVGPoint>().Invoke(matrix);
	}
}