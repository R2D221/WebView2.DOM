using NodaTime;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/idle_request_options.idl

	[JsonConverter(typeof(Converter))]
	public record IdleRequestOptions : JsDictionary
	{
		private class Converter : Converter<IdleRequestOptions> { }

		public required Duration timeout
		{
			get => Duration.FromMilliseconds(GetRequired<uint>());
			init => Set((uint)value.TotalMilliseconds);
		}
	}
}