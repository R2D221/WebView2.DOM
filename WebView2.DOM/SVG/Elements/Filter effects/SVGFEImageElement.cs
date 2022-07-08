namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_image_element.idl

	public sealed partial class SVGFEImageElement : SVGElement
	{
		private SVGFEImageElement() { }

		public SVGAnimatedPreserveAspectRatio preserveAspectRatio =>
			Get<SVGAnimatedPreserveAspectRatio>();
	}

	public partial class SVGFEImageElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedString result => Get<SVGAnimatedString>();
	}

	public partial class SVGFEImageElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}