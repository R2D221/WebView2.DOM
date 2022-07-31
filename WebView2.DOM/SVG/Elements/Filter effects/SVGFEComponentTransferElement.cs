namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_component_transfer_element.idl

	public sealed partial class SVGFEComponentTransferElement : SVGElement
	{
		private SVGFEComponentTransferElement() { }

		public SVGAnimatedString in1 => GetCached<SVGAnimatedString>();
	}

	public partial class SVGFEComponentTransferElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}
}