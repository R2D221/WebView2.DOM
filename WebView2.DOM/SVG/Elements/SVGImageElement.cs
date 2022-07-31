namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_image_element.idl

	public sealed partial class SVGImageElement : SVGGraphicsElement
	{
		private SVGImageElement() { }

		public SVGAnimatedLength x => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength y => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength width => GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength height => GetCached<SVGAnimatedLength>();
		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => GetCached<SVGAnimatedPreserveAspectRatio>();

		public ImageDecodingHint decoding { get => Get<ImageDecodingHint>(); set => Set(value); }
		public VoidPromise decode() => Method<VoidPromise>().Invoke();
	}

	public partial class SVGImageElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}
}