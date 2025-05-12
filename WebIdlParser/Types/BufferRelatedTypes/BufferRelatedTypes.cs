namespace WebIdlParser
{
	internal sealed class ArrayBuffer : Type
	{
		private ArrayBuffer() : base("ArrayBuffer") { }

		public static ArrayBuffer Instance { get; } = new();
	}
	internal sealed class DataView : Type
	{
		private DataView() : base("DataView") { }

		public static DataView Instance { get; } = new();
	}
	internal sealed class Int8Array : Type
	{
		private Int8Array() : base("Int8Array") { }

		public static Int8Array Instance { get; } = new();
	}
	internal sealed class Int16Array : Type
	{
		private Int16Array() : base("Int16Array") { }

		public static Int16Array Instance { get; } = new();
	}
	internal sealed class Int32Array : Type
	{
		private Int32Array() : base("Int32Array") { }

		public static Int32Array Instance { get; } = new();
	}
	internal sealed class Uint8Array : Type
	{
		private Uint8Array() : base("Uint8Array") { }

		public static Uint8Array Instance { get; } = new();
	}
	internal sealed class Uint16Array : Type
	{
		private Uint16Array() : base("Uint16Array") { }

		public static Uint16Array Instance { get; } = new();
	}
	internal sealed class Uint32Array : Type
	{
		private Uint32Array() : base("Uint32Array") { }

		public static Uint32Array Instance { get; } = new();
	}
	internal sealed class Uint8ClampedArray : Type
	{
		private Uint8ClampedArray() : base("Uint8ClampedArray") { }

		public static Uint8ClampedArray Instance { get; } = new();
	}
	internal sealed class BigInt64Array : Type
	{
		private BigInt64Array() : base("BigInt64Array") { }

		public static BigInt64Array Instance { get; } = new();
	}
	internal sealed class BigUint64Array : Type
	{
		private BigUint64Array() : base("BigUint64Array") { }

		public static BigUint64Array Instance { get; } = new();
	}
	internal sealed class Float32Array : Type
	{
		private Float32Array() : base("Float32Array") { }

		public static Float32Array Instance { get; } = new();
	}
	internal sealed class Float64Array : Type
	{
		private Float64Array() : base("Float64Array") { }

		public static Float64Array Instance { get; } = new();
	}
}