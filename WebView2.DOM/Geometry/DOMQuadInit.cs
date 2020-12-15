using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_quad_init.idl

	public record DOMQuadInit
	{
		[JsonIgnore] public DOMPointInit p1 { get => _p1 ?? new(); init => _p1 = value; }
		[JsonIgnore] public DOMPointInit p2 { get => _p2 ?? new(); init => _p2 = value; }
		[JsonIgnore] public DOMPointInit p3 { get => _p3 ?? new(); init => _p3 = value; }
		[JsonIgnore] public DOMPointInit p4 { get => _p4 ?? new(); init => _p4 = value; }

		[JsonPropertyName(nameof(p1))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p1 { get; init; }

		[JsonPropertyName(nameof(p2))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p2 { get; init; }

		[JsonPropertyName(nameof(p3))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p3 { get; init; }

		[JsonPropertyName(nameof(p4))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p4 { get; init; }
	}
}
