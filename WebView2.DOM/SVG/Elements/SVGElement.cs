namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_element.idl

	public abstract partial class SVGElement : Element
	{
		private protected SVGElement() { }

		new public SVGAnimatedString className => GetCached<SVGAnimatedString>();
		public CSSStyleDeclaration style => GetCached<CSSStyleDeclaration>();

		public SVGSVGElement? ownerSVGElement => Get<SVGSVGElement>();
		public SVGElement? viewportElement => Get<SVGElement>();
	}
}