using SmartAnalyzers.CSharpExtensions.Annotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

#pragma warning disable CSE004
namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_point_init.idl

	public interface IDOMPointInit
	{
		double x { get; }
		double y { get; }
		double z { get; }
		double w { get; }
	}

	public record DOMPointInit : IDOMPointInit
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
		public double z
		{
			get => _z ?? 0;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _z = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public double w
		{
			get => _w ?? 1;
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _w = value;
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

		[JsonPropertyName(nameof(z))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _z
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(w))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _w
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
