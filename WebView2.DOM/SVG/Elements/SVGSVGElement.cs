using Microsoft.Web.WebView2.Core;
using NodaTime;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_svg_element.idl

	public partial class SVGSVGElement : SVGGraphicsElement
	{
		protected internal SVGSVGElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();

		public float currentScale { get => Get<float>(); set => Set(value); }
		public SVGPoint currentTranslate => Get<SVGPoint>();

		public NodeList getIntersectionList(SVGRect rect, SVGElement? referenceElement) =>
			Method<NodeList>().Invoke(rect, referenceElement);
		public NodeList getEnclosureList(SVGRect rect, SVGElement? referenceElement) =>
			Method<NodeList>().Invoke(rect, referenceElement);
		public bool checkIntersection(SVGElement element, SVGRect rect) =>
			Method<bool>().Invoke(element, rect);
		public bool checkEnclosure(SVGElement element, SVGRect rect) =>
			Method<bool>().Invoke(element, rect);

		public void deselectAll() => Method().Invoke();

		public SVGNumber createSVGNumber() =>
			Method<SVGNumber>().Invoke();
		public SVGLength createSVGLength() =>
			Method<SVGLength>().Invoke();
		public SVGAngle createSVGAngle() =>
			Method<SVGAngle>().Invoke();
		public SVGPoint createSVGPoint() =>
			Method<SVGPoint>().Invoke();
		public SVGMatrix createSVGMatrix() =>
			Method<SVGMatrix>().Invoke();
		public SVGRect createSVGRect() =>
			Method<SVGRect>().Invoke();
		public SVGTransform createSVGTransform() =>
			Method<SVGTransform>().Invoke();
		public SVGTransform createSVGTransformFromMatrix(SVGMatrix matrix) =>
			Method<SVGTransform>().Invoke(matrix);

		public Element getElementById(string elementId) =>
			Method<Element>().Invoke(elementId);

		// SVG Animations
		public void pauseAnimations() => Method().Invoke();
		public void unpauseAnimations() => Method().Invoke();
		public bool animationsPaused() => Method<bool>().Invoke();
		public Duration getCurrentTime() =>
			Duration.FromSeconds(Method<float>().Invoke());
		public void setCurrentTime(Duration time) =>
			Method().Invoke((float)time.TotalSeconds);
	}
}
