namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_component_transfer_element.idl

	public sealed partial class SVGFEComponentTransferElement : SVGElement
	{
		private SVGFEComponentTransferElement() { }

		public SVGAnimatedString in1 => Get<SVGAnimatedString>();
	}

	public partial class SVGFEComponentTransferElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}
}