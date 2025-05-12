using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class BigUint64Array : BigIntegerTypedArray<BigUint64Array, UInt64>
	{
		public BigUint64Array() =>
			Construct();

		public BigUint64Array(uint length) =>
			Construct(length);

		public BigUint64Array(BigUint64Array array) =>
			Construct(array);

		public BigUint64Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public BigUint64Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public BigUint64Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public BigUint64Array(IReadOnlyList<UInt64> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 8;
	}
}
