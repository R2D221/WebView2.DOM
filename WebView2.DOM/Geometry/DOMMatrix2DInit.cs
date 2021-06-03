using SmartAnalyzers.CSharpExtensions.Annotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

#pragma warning disable CSE004
namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix_2d_init.idl

	public record DOMMatrix2DInit
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double a
		{
			get => _a/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _a = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double b
		{
			get => _b/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _b = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double c
		{
			get => _c/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _c = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double d
		{
			get => _d/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _d = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double e
		{
			get => _e/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _e = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double f
		{
			get => _f/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _f = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m11
		{
			get => _m11/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m11 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m12
		{
			get => _m12/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m12 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m21
		{
			get => _m21/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m21 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m22
		{
			get => _m22/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m22 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m41
		{
			get => _m41/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m41 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m42
		{
			get => _m42/*	*/?? double.NaN;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m42 = value;
		}

		[JsonPropertyName(nameof(a))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _a
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(b))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _b
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(c))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _c
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(d))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _d
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(e))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _e
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(f))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _f
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m11))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m11
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m12))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m12
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m21))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m21
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m22))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m22
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m41))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m41
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m42))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m42
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
#pragma warning restore CSE004