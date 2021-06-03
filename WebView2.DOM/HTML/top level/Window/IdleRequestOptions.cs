using NodaTime;
using SmartAnalyzers.CSharpExtensions.Annotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/idle_request_options.idl

	public record IdleRequestOptions
	{
		[JsonIgnore]
		[InitOnly]
		public Duration timeout
		{
			get => Duration.FromMilliseconds(_timeout);
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _timeout = (uint)value.TotalMilliseconds;
		}

		[JsonPropertyName(nameof(timeout))]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _timeout
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
	}
}