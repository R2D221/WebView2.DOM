using SmartAnalyzers.CSharpExtensions.Annotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

#pragma warning disable CSE004
namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix_init.idl

	public record DOMMatrixInit : DOMMatrix2DInit
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m13
		{
			get => _m13 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m13 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m14
		{
			get => _m14 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m14 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m23
		{
			get => _m23 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m23 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m24
		{
			get => _m24 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m24 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m31
		{
			get => _m31 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m31 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m32
		{
			get => _m32 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m32 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m33
		{
			get => _m33 ?? 1;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m33 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m34
		{
			get => _m34 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m34 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m43
		{
			get => _m43 ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m43 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double m44
		{
			get => _m44 ?? 1;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _m44 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public bool is2D
		{
			get => _is2D ?? true;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _is2D = value;
		}

		[JsonPropertyName(nameof(m13))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m13
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m14))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m14
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m23))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m23
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m24))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m24
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m31))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m31
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m32))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m32
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m33))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m33
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m34))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m34
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m43))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m43
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(m44))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _m44
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(is2D))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool? _is2D
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
