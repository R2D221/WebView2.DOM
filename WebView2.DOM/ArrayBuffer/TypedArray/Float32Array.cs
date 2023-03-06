global using Float32 = System.Single;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class Float32Array : PrimitiveTypedArray<Float32Array, Float32>
	{
		public Float32Array() =>
			Construct();

		public Float32Array(uint length) =>
			Construct(length);

		public Float32Array(Float32Array array) =>
			Construct(array);

		public Float32Array(ArrayBuffer buffer) =>
			Construct(buffer);
		public Float32Array(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public Float32Array(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public Float32Array(IReadOnlyList<Float32> array) =>
			Construct(array);

		protected override int _BYTES_PER_ELEMENT => BYTES_PER_ELEMENT;

		new public const int BYTES_PER_ELEMENT = 4;
	}
}
