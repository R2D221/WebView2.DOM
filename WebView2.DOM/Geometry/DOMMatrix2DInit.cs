using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix_2d_init.idl

	public record DOMMatrix2DInit
	{
		[JsonIgnore]
		public double a
		{
			get => _a/*	*/?? double.NaN;
			init => _a = value;
		}

		[JsonIgnore]
		public double b
		{
			get => _b/*	*/?? double.NaN;
			init => _b = value;
		}

		[JsonIgnore]
		public double c
		{
			get => _c/*	*/?? double.NaN;
			init => _c = value;
		}

		[JsonIgnore]
		public double d
		{
			get => _d/*	*/?? double.NaN;
			init => _d = value;
		}

		[JsonIgnore]
		public double e
		{
			get => _e/*	*/?? double.NaN;
			init => _e = value;
		}

		[JsonIgnore]
		public double f
		{
			get => _f/*	*/?? double.NaN;
			init => _f = value;
		}

		[JsonIgnore]
		public double m11
		{
			get => _m11/*	*/?? double.NaN;
			init => _m11 = value;
		}

		[JsonIgnore]
		public double m12
		{
			get => _m12/*	*/?? double.NaN;
			init => _m12 = value;
		}

		[JsonIgnore]
		public double m21
		{
			get => _m21/*	*/?? double.NaN;
			init => _m21 = value;
		}

		[JsonIgnore]
		public double m22
		{
			get => _m22/*	*/?? double.NaN;
			init => _m22 = value;
		}

		[JsonIgnore]
		public double m41
		{
			get => _m41/*	*/?? double.NaN;
			init => _m41 = value;
		}

		[JsonIgnore]
		public double m42
		{
			get => _m42/*	*/?? double.NaN;
			init => _m42 = value;
		}

		[JsonPropertyName(nameof(a))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _a { get; init; }

		[JsonPropertyName(nameof(b))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _b { get; init; }

		[JsonPropertyName(nameof(c))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _c { get; init; }

		[JsonPropertyName(nameof(d))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _d { get; init; }

		[JsonPropertyName(nameof(e))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _e { get; init; }

		[JsonPropertyName(nameof(f))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _f { get; init; }

		[JsonPropertyName(nameof(m11))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m11 { get; init; }

		[JsonPropertyName(nameof(m12))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m12 { get; init; }

		[JsonPropertyName(nameof(m21))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m21 { get; init; }

		[JsonPropertyName(nameof(m22))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m22 { get; init; }

		[JsonPropertyName(nameof(m41))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m41 { get; init; }

		[JsonPropertyName(nameof(m42))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m42 { get; init; }
	}
}
