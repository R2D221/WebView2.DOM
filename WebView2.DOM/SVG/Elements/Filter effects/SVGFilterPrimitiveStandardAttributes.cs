namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_filter_primitive_standard_attributes.idl

	public interface SVGFilterPrimitiveStandardAttributes
	{
		SVGAnimatedLength x { get; }
		SVGAnimatedLength y { get; }
		SVGAnimatedLength width { get; }
		SVGAnimatedLength height { get; }
		SVGAnimatedString result { get; }
	}
}