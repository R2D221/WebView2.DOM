namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_element.idl

	public abstract partial class SVGElement : Element
	{
		private protected SVGElement() { }

		new public SVGAnimatedString className => Get<SVGAnimatedString>();
		public CSSStyleDeclaration style => _style ??= Get<CSSStyleDeclaration>();
		private CSSStyleDeclaration? _style;

		public SVGSVGElement? ownerSVGElement => Get<SVGSVGElement>();
		public SVGElement? viewportElement => Get<SVGElement>();
	}
}