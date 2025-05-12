using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Type
	{
		public static Type Any { get; } = WebIdlParser.Any.Instance;
		public static Type Object { get; } = WebIdlParser.Object.Instance;
		public static Type Symbol { get; } = WebIdlParser.Symbol.Instance;
		public static Type Undefined { get; } = WebIdlParser.Undefined.Instance;

		#region Primitive types
		public static Type Boolean { get; } = WebIdlParser.Boolean.Instance;
		public static Type Byte { get; } = WebIdlParser.Byte.Instance;
		public static Type Octet { get; } = WebIdlParser.Octet.Instance;
		public static Type BigInt { get; } = WebIdlParser.BigInt.Instance;
		public static Type Float { get; } = WebIdlParser.Float.Instance;
		public static Type Double { get; } = WebIdlParser.Double.Instance;
		public static Type Short { get; } = WebIdlParser.Short.Instance;
		public static Type LongLong { get; } = WebIdlParser.LongLong.Instance;
		public static Type Long { get; } = WebIdlParser.Long.Instance;
		public static Type UnrestrictedFloat { get; } = WebIdlParser.UnrestrictedFloat.Instance;
		public static Type UnrestrictedDouble { get; } = WebIdlParser.UnrestrictedDouble.Instance;
		public static Type UnsignedShort { get; } = WebIdlParser.UnsignedShort.Instance;
		public static Type UnsignedLongLong { get; } = WebIdlParser.UnsignedLongLong.Instance;
		public static Type UnsignedLong { get; } = WebIdlParser.UnsignedLong.Instance;
		#endregion
		#region String types
		public static Type ByteString { get; } = WebIdlParser.ByteString.Instance;
		public static Type DOMString { get; } = WebIdlParser.DOMString.Instance;
		public static Type USVString { get; } = WebIdlParser.USVString.Instance;
		#endregion
		#region Buffer related types
		public static Type ArrayBuffer { get; } = WebIdlParser.ArrayBuffer.Instance;
		public static Type DataView { get; } = WebIdlParser.DataView.Instance;
		public static Type Int8Array { get; } = WebIdlParser.Int8Array.Instance;
		public static Type Int16Array { get; } = WebIdlParser.Int16Array.Instance;
		public static Type Int32Array { get; } = WebIdlParser.Int32Array.Instance;
		public static Type Uint8Array { get; } = WebIdlParser.Uint8Array.Instance;
		public static Type Uint16Array { get; } = WebIdlParser.Uint16Array.Instance;
		public static Type Uint32Array { get; } = WebIdlParser.Uint32Array.Instance;
		public static Type Uint8ClampedArray { get; } = WebIdlParser.Uint8ClampedArray.Instance;
		public static Type BigInt64Array { get; } = WebIdlParser.BigInt64Array.Instance;
		public static Type BigUint64Array { get; } = WebIdlParser.BigUint64Array.Instance;
		public static Type Float32Array { get; } = WebIdlParser.Float32Array.Instance;
		public static Type Float64Array { get; } = WebIdlParser.Float64Array.Instance;
		#endregion

		public Type(string name)
		{
			Name = name;
		}

		public string Name { get; }
		public bool IsNullable { get; set; }

		protected virtual string DebuggerDisplay =>
			$"{Name}{IsNullable switch { true => " ?", false => "" }}";

		public override string ToString() => DebuggerDisplay;
	}
}