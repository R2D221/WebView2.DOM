using NodaTime;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/idle_request_options.idl

	public record IdleRequestOptions
	{
		[JsonIgnore]
		public required Duration timeout
		{
			get => Duration.FromMilliseconds(_timeout);
			init => _timeout = (uint)value.TotalMilliseconds;
		}

		[JsonPropertyName(nameof(timeout))]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _timeout { get; init; }
	}
}