using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_graphics_element.idl

	public partial class SVGGraphicsElement : SVGElement
	{
		protected internal SVGGraphicsElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedTransformList transform =>
			Get<SVGAnimatedTransformList>();

		public SVGRect getBBox() => Method<SVGRect>().Invoke();
		public SVGMatrix getCTM() => Method<SVGMatrix>().Invoke();
		public SVGMatrix getScreenCTM() => Method<SVGMatrix>().Invoke();

		public SVGElement nearestViewportElement => Get<SVGElement>();
		public SVGElement farthestViewportElement => Get<SVGElement>();
	}
}