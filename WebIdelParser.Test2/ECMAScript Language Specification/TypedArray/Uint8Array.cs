global using UInt8 = System.Byte;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Uint8Array : PrimitiveTypedArray<Uint8Array, UInt8>
	{
		public Uint8Array() =>
			Construct();

		public Uint8Array(uint length) =>
			Construct(length);

		public Uint8Array(Uint8Array array) =>
			Construct(array);

		public Uint8Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Uint8Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Uint8Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Uint8Array(IReadOnlyList<UInt8> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 1;
	}
}
