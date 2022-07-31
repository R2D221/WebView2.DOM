namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_use_element.idl

	public sealed partial class SVGUseElement : SVGGraphicsElement
	{
		private SVGUseElement() { }

		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
	}

	public partial class SVGUseElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}
}