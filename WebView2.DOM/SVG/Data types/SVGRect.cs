namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_rect.idl

	public sealed class SVGRect : JsObject
	{
		private SVGRect() { }

		public float x { get => Get<float>(); set => Set(value); }
		public float y { get => Get<float>(); set => Set(value); }
		public float width { get => Get<float>(); set => Set(value); }
		public float height { get => Get<float>(); set => Set(value); }
	}
}