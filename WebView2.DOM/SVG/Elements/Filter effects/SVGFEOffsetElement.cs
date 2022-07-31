namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_offset_element.idl

	public sealed partial class SVGFEOffsetElement : SVGElement
	{
		private SVGFEOffsetElement() { }

		public SVGAnimatedString in1 => GetCached<SVGAnimatedString>();
		public SVGAnimatedNumber dx => GetCached<SVGAnimatedNumber>();
		public SVGAnimatedNumber dy => GetCached<SVGAnimatedNumber>();
	}

	public partial class SVGFEOffsetElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}