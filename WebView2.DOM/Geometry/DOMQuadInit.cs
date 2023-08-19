using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_quad_init.idl

	[JsonConverter(typeof(Converter))]
	public record DOMQuadInit : JsDictionary
	{
		private class Converter : Converter<DOMQuadInit> { }

		public DOMPointInit p1
		{
			get => GetRequired<DOMPointInit>();
			init => Set(value);
		}

		public DOMPointInit p2
		{
			get => GetRequired<DOMPointInit>();
			init => Set(value);
		}

		public DOMPointInit p3
		{
			get => GetRequired<DOMPointInit>();
			init => Set(value);
		}

		public DOMPointInit p4
		{
			get => GetRequired<DOMPointInit>();
			init => Set(value);
		}
	}
}
