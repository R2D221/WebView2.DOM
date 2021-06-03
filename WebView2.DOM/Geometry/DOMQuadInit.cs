using SmartAnalyzers.CSharpExtensions.Annotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

#pragma warning disable CSE004
namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_quad_init.idl

	public record DOMQuadInit
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public DOMPointInit p1
		{
			get => _p1 ?? new();
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _p1 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public DOMPointInit p2
		{
			get => _p2 ?? new();
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _p2 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public DOMPointInit p3
		{
			get => _p3 ?? new();
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _p3 = value;
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		[JsonIgnore]
		public DOMPointInit p4
		{
			get => _p4 ?? new();
#if NET5_0_OR_GREATER
			init
#else
			set
#endif
				=> _p4 = value;
		}

		[JsonPropertyName(nameof(p1))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p1
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(p2))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p2
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(p3))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p3
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

		[JsonPropertyName(nameof(p4))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DOMPointInit? _p4
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
