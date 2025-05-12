using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class BigInt64Array : BigIntegerTypedArray<BigInt64Array, Int64>
	{
		public BigInt64Array() =>
			Construct();

		public BigInt64Array(uint length) =>
			Construct(length);

		public BigInt64Array(BigInt64Array array) =>
			Construct(array);

		public BigInt64Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public BigInt64Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public BigInt64Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public BigInt64Array(IReadOnlyList<Int64> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 8;
	}
}
