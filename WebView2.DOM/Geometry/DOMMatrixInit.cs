using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix_init.idl

	public record DOMMatrixInit : DOMMatrix2DInit
	{
		[JsonIgnore] public double m13 { get => _m13 ?? 0; init => _m13 = value; }
		[JsonIgnore] public double m14 { get => _m14 ?? 0; init => _m14 = value; }
		[JsonIgnore] public double m23 { get => _m23 ?? 0; init => _m23 = value; }
		[JsonIgnore] public double m24 { get => _m24 ?? 0; init => _m24 = value; }
		[JsonIgnore] public double m31 { get => _m31 ?? 0; init => _m31 = value; }
		[JsonIgnore] public double m32 { get => _m32 ?? 0; init => _m32 = value; }
		[JsonIgnore] public double m33 { get => _m33 ?? 1; init => _m33 = value; }
		[JsonIgnore] public double m34 { get => _m34 ?? 0; init => _m34 = value; }
		[JsonIgnore] public double m43 { get => _m43 ?? 0; init => _m43 = value; }
		[JsonIgnore] public double m44 { get => _m44 ?? 1; init => _m44 = value; }
		[JsonIgnore] public bool is2D { get => _is2D ?? true; init => _is2D = value; }

		[JsonPropertyName(nameof(m13))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m13 { get; init; }

		[JsonPropertyName(nameof(m14))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m14 { get; init; }

		[JsonPropertyName(nameof(m23))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m23 { get; init; }

		[JsonPropertyName(nameof(m24))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m24 { get; init; }

		[JsonPropertyName(nameof(m31))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m31 { get; init; }

		[JsonPropertyName(nameof(m32))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m32 { get; init; }

		[JsonPropertyName(nameof(m33))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m33 { get; init; }

		[JsonPropertyName(nameof(m34))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m34 { get; init; }

		[JsonPropertyName(nameof(m43))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m43 { get; init; }

		[JsonPropertyName(nameof(m44))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m44 { get; init; }

		[JsonPropertyName(nameof(is2D))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool? _is2D { get; init; }
	}
}
