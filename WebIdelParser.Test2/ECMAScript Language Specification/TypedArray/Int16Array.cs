using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Int16Array : PrimitiveTypedArray<Int16Array, Int16>
	{
		public Int16Array() =>
			Construct();

		public Int16Array(uint length) =>
			Construct(length);

		public Int16Array(Int16Array array) =>
			Construct(array);

		public Int16Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Int16Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Int16Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Int16Array(IReadOnlyList<Int16> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 2;
	}
}
