using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

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
		[JsonIgnore]
		public double x
		{
			get => _x ?? 0;
			init => _x = value;
		}

		[JsonIgnore]
		public double y
		{
			get => _y ?? 0;
			init => _y = value;
		}

		[JsonIgnore]
		public double z
		{
			get => _z ?? 0;
			init => _z = value;
		}

		[JsonIgnore]
		public double w
		{
			get => _w ?? 1;
			init => _w = value;
		}

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

		[JsonPropertyName(nameof(z))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _z { get; init; }

		[JsonPropertyName(nameof(w))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double? _w { get; init; }
	}
}
