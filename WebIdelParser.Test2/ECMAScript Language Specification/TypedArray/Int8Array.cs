global using Int8 = System.SByte;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Int8Array : PrimitiveTypedArray<Int8Array, Int8>
	{
		public Int8Array() =>
			Construct();

		public Int8Array(uint length) =>
			Construct(length);

		public Int8Array(Int8Array array) =>
			Construct(array);

		public Int8Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Int8Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Int8Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Int8Array(IReadOnlyList<Int8> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 1;
	}
}
