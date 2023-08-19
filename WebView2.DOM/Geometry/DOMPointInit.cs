using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_point_init.idl

	public interface IDOMPointInit
	{
		double x { get; }
		double y { get; }
		double z { get; }
		double w { get; }
	}

	[JsonConverter(typeof(Converter))]
	public record DOMPointInit : JsDictionary, IDOMPointInit
	{
		private class Converter : Converter<DOMPointInit> { }

		public double x
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double y
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double z
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double w
		{
			get => Get<double>(defaultValue: 1);
			init => Set(value);
		}
	}
}
