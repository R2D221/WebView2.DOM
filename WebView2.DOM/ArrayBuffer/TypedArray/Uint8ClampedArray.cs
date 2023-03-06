using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Uint8ClampedArray : PrimitiveTypedArray<Uint8ClampedArray, UInt8>
	{
		public Uint8ClampedArray() =>
			Construct();

		public Uint8ClampedArray(uint length) =>
			Construct(length);

		public Uint8ClampedArray(Uint8ClampedArray array) =>
			Construct(array);

		public Uint8ClampedArray(ArrayBuffer buffer) =>
			Construct(buffer);
		public Uint8ClampedArray(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Uint8ClampedArray(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Uint8ClampedArray(IReadOnlyList<UInt8> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 1;
	}
}
