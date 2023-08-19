using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix_init.idl

	[JsonConverter(typeof(Converter))]
	public record DOMMatrixInit : DOMMatrix2DInit
	{
		private class Converter : Converter<DOMMatrixInit> { }

		public double m13
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m14
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m23
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m24
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m31
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m32
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m33
		{
			get => Get<double>(defaultValue: 1);
			init => Set(value);
		}

		public double m34
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m43
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double m44
		{
			get => Get<double>(defaultValue: 1);
			init => Set(value);
		}

		public bool is2D
		{
			get => GetRequired<bool>();
			init => Set(value);
		}
	}
}
