global using Float64 = System.Double;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Float64Array : PrimitiveTypedArray<Float64Array, Float64>
	{
		public Float64Array() =>
			Construct();

		public Float64Array(uint length) =>
			Construct(length);

		public Float64Array(Float64Array array) =>
			Construct(array);

		public Float64Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Float64Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Float64Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Float64Array(IReadOnlyList<Float64> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 8;
	}
}
