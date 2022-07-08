namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_script_element.idl

	public sealed partial class SVGScriptElement : SVGElement
	{
		private SVGScriptElement() { }

		public string type { get => Get<string>(); set => Set(value); }
	}

	public partial class SVGScriptElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}