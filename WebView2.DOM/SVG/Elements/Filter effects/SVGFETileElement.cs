namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_tile_element.idl

	public sealed partial class SVGFETileElement : SVGElement
	{
		private SVGFETileElement() { }

		public SVGAnimatedString in1 => GetCached<SVGAnimatedString>();
	}

	public partial class SVGFETileElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}