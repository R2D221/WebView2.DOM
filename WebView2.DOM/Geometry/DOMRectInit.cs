using SmartAnalyzers.CSharpExtensions.Annotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

#pragma warning disable CSE004
namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect_init.idl

	public record DOMRectInit
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double x
		{
			get => _x ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _x = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double y
		{
			get => _y ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _y = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double width
		{
			get => _width ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _width = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double height
		{
			get => _height ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _height = value;
		}

		[JsonPropertyName(nameof(x))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _x
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(y))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _y
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(width))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _width
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(height))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _height
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
