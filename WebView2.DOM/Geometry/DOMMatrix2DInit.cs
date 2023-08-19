using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix_2d_init.idl

	[JsonConverter(typeof(Converter))]
	public record DOMMatrix2DInit : JsDictionary
	{
		private class Converter : Converter<DOMMatrix2DInit> { }

		public double a
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double b
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double c
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double d
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double e
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double f
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double m11
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double m12
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double m21
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double m22
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double m41
		{
			get => GetRequired<double>();
			init => Set(value);
		}

		public double m42
		{
			get => GetRequired<double>();
			init => Set(value);
		}
	}
}
