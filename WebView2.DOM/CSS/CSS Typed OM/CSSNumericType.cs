using System.Text.Json.Serialization;

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

	[JsonConverter(typeof(Converter))]
	public record CSSNumericType : JsDictionary
	{
		private class Converter : Converter<CSSNumericType> { }

		public required int length
		{
			get => GetRequired<int>();
			init => Set(value);
		}

		public required int angle
		{
			get => GetRequired<int>();
			init => Set(value);
		}

		public required int time
		{
			get => GetRequired<int>();
			init => Set(value);
		}

		public required int frequency
		{
			get => GetRequired<int>();
			init => Set(value);
		}

		public required int resolution
		{
			get => GetRequired<int>();
			init => Set(value);
		}

		public required int flex
		{
			get => GetRequired<int>();
			init => Set(value);
		}

		public required int percent
		{
			get => GetRequired<int>();
			init => Set(value);
		}

		public required CSSNumericBaseType percentHint
		{
			get => GetRequired<CSSNumericBaseType>();
			init => Set(value);
		}
	}
}
