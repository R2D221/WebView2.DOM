using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Uint16Array : PrimitiveTypedArray<Uint16Array, UInt16>
	{
		public Uint16Array() =>
			Construct();

		public Uint16Array(uint length) =>
			Construct(length);

		public Uint16Array(Uint16Array array) =>
			Construct(array);

		public Uint16Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Uint16Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Uint16Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Uint16Array(IReadOnlyList<UInt16> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 2;
	}
}
