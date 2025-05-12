using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Uint32Array : PrimitiveTypedArray<Uint32Array, UInt32>
	{
		public Uint32Array() =>
			Construct();

		public Uint32Array(uint length) =>
			Construct(length);

		public Uint32Array(Uint32Array array) =>
			Construct(array);

		public Uint32Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Uint32Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Uint32Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Uint32Array(IReadOnlyList<UInt32> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 4;
	}
}
