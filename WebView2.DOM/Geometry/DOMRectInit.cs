using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect_init.idl

	[JsonConverter(typeof(Converter))]
	public record DOMRectInit : JsDictionary
	{
		private class Converter : Converter<DOMRectInit> { }

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

		public double width
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double height
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}
	}
}
