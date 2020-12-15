using SmartAnalyzers.CSharpExtensions.Annotations;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_numeric_type.idl

	public enum CSSNumericBaseType
	{
		length,
		angle,
		time,
		frequency,
		resolution,
		flex,
		percent,
	};

	public record CSSNumericType
	{
		public int length { get; init; }
		public int angle { get; init; }
		public int time { get; init; }
		public int frequency { get; init; }
		public int resolution { get; init; }
		public int flex { get; init; }
		public int percent { get; init; }
		public CSSNumericBaseType percentHint { get; init; }
	}
}
