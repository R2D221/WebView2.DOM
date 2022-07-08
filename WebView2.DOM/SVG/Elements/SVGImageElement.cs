namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_image_element.idl

	public sealed partial class SVGImageElement : SVGGraphicsElement
	{
		private SVGImageElement() { }

		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => Get<SVGAnimatedPreserveAspectRatio>();

		public ImageDecodingHint decoding { get => Get<ImageDecodingHint>(); set => Set(value); }
		public VoidPromise decode() => Method<VoidPromise>().Invoke();
	}

	public partial class SVGImageElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}