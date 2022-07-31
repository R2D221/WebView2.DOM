namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_image_element.idl

	public sealed partial class SVGFEImageElement : SVGElement
	{
		private SVGFEImageElement() { }

		public SVGAnimatedPreserveAspectRatio preserveAspectRatio =>
			GetCached<SVGAnimatedPreserveAspectRatio>();
	}

	public partial class SVGFEImageElement : SVGFilterPrimitiveStandardAttributes
	{
		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedString result => GetCached<SVGAnimatedString>();
	}

	public partial class SVGFEImageElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}
}