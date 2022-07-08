namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_number.idl

	public sealed class SVGNumber : JsObject
	{
		private SVGNumber() { }

		public float value { get => Get<float>(); set => Set(value); }
	}
}