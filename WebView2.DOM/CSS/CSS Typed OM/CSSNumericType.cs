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
		public required int length { get; init; }

		public required int angle { get; init; }

		public required int time { get; init; }

		public required int frequency { get; init; }

		public required int resolution { get; init; }

		public required int flex { get; init; }

		public required int percent { get; init; }

		public required CSSNumericBaseType percentHint { get; init; }
	}
}
