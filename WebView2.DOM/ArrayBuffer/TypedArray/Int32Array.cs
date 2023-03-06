using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Int32Array : PrimitiveTypedArray<Int32Array, Int32>
	{
		public Int32Array() =>
			Construct();

		public Int32Array(uint length) =>
			Construct(length);

		public Int32Array(Int32Array array) =>
			Construct(array);

		public Int32Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Int32Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Int32Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Int32Array(IReadOnlyList<Int32> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 4;
	}
}
