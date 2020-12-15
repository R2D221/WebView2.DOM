using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect_init.idl

	public record DOMRectInit
	{
		[JsonIgnore] public double x { get => _x ?? 0; init => _x = value; }
		[JsonIgnore] public double y { get => _y ?? 0; init => _y = value; }
		[JsonIgnore] public double width { get => _width ?? 0; init => _width = value; }
		[JsonIgnore] public double height { get => _height ?? 0; init => _height = value; }

		[JsonPropertyName(nameof(x))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _x { get; init; }

		[JsonPropertyName(nameof(y))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _y { get; init; }

		[JsonPropertyName(nameof(width))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _width { get; init; }

		[JsonPropertyName(nameof(height))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _height { get; init; }
	}
}
