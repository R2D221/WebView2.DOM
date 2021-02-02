namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_tests.idl

	public interface SVGTests
	{
		SVGStringList requiredExtensions { get; }
		SVGStringList systemLanguage { get; }
	}
}