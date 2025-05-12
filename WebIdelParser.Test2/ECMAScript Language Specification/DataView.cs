using System;
using System.Numerics;

namespace WebView2.DOM
{
	public class DataView : JsObject, ArrayBufferView
	{
		public DataView(ArrayBuffer buffer) =>
			Construct(buffer);
		public DataView(ArrayBuffer buffer, uint byteOffset) =>
			Construct(buffer, byteOffset);
		public DataView(ArrayBuffer buffer, uint byteOffset, int length) =>
			Construct(buffer, byteOffset, length);

		public ArrayBuffer buffer => GetCached<ArrayBuffer>();

		public uint byteLength => GetCached<uint>();

		public uint byteOffset => GetCached<uint>();

		public Int8 getInt8(uint byteOffset) => Method<Int8>().Invoke(byteOffset);
		public UInt8 getUint8(uint byteOffset) => Method<UInt8>().Invoke(byteOffset);
		public Int16 getInt16(uint byteOffset) => Method<Int16>().Invoke(byteOffset);
		public Int16 getInt16(uint byteOffset, bool littleEndian) => Method<Int16>().Invoke(byteOffset, littleEndian);
		public UInt16 getUint16(uint byteOffset) => Method<UInt16>().Invoke(byteOffset);
		public UInt16 getUint16(uint byteOffset, bool littleEndian) => Method<UInt16>().Invoke(byteOffset, littleEndian);
		public Int32 getInt32(uint byteOffset) => Method<Int32>().Invoke(byteOffset);
		public Int32 getInt32(uint byteOffset, bool littleEndian) => Method<Int32>().Invoke(byteOffset, littleEndian);
		public UInt32 getUint32(uint byteOffset) => Method<UInt32>().Invoke(byteOffset);
		public UInt32 getUint32(uint byteOffset, bool littleEndian) => Method<UInt32>().Invoke(byteOffset, littleEndian);
		public Float32 getFloat32(uint byteOffset) => Method<Float32>().Invoke(byteOffset);
		public Float32 getFloat32(uint byteOffset, bool littleEndian) => Method<Float32>().Invoke(byteOffset, littleEndian);
		public Float64 getFloat64(uint byteOffset) => Method<Float64>().Invoke(byteOffset);
		public Float64 getFloat64(uint byteOffset, bool littleEndian) => Method<Float64>().Invoke(byteOffset, littleEndian);
		public Int64 getBigInt64(uint byteOffset) => (Int64)(Method<BigInteger>().Invoke(byteOffset));
		public Int64 getBigInt64(uint byteOffset, bool littleEndian) => (Int64)(Method<BigInteger>().Invoke(byteOffset, littleEndian));
		public UInt64 getBigUint64(uint byteOffset) => (UInt64)(Method<BigInteger>().Invoke(byteOffset));
		public UInt64 getBigUint64(uint byteOffset, bool littleEndian) => (UInt64)(Method<BigInteger>().Invoke(byteOffset, littleEndian));

		public void setInt8(uint byteOffset, Int8 value) => Method().Invoke(byteOffset, value);
		public void setUint8(uint byteOffset, UInt8 value) => Method().Invoke(byteOffset, value);
		public void setInt16(uint byteOffset, Int16 value) => Method().Invoke(byteOffset, value);
		public void setInt16(uint byteOffset, Int16 value, bool littleEndian) => Method().Invoke(byteOffset, value, littleEndian);
		public void setUint16(uint byteOffset, UInt16 value) => Method().Invoke(byteOffset, value);
		public void setUint16(uint byteOffset, UInt16 value, bool littleEndian) => Method().Invoke(byteOffset, value, littleEndian);
		public void setInt32(uint byteOffset, Int32 value) => Method().Invoke(byteOffset, value);
		public void setInt32(uint byteOffset, Int32 value, bool littleEndian) => Method().Invoke(byteOffset, value, littleEndian);
		public void setUint32(uint byteOffset, UInt32 value) => Method().Invoke(byteOffset, value);
		public void setUint32(uint byteOffset, UInt32 value, bool littleEndian) => Method().Invoke(byteOffset, value, littleEndian);
		public void setFloat32(uint byteOffset, Float32 value) => Method().Invoke(byteOffset, value);
		public void setFloat32(uint byteOffset, Float32 value, bool littleEndian) => Method().Invoke(byteOffset, value, littleEndian);
		public void setFloat64(uint byteOffset, Float64 value) => Method().Invoke(byteOffset, value);
		public void setFloat64(uint byteOffset, Float64 value, bool littleEndian) => Method().Invoke(byteOffset, value, littleEndian);
		public void setBigInt64(uint byteOffset, Int64 value) => Method().Invoke(byteOffset, (BigInteger)(value));
		public void setBigInt64(uint byteOffset, Int64 value, bool littleEndian) => Method().Invoke(byteOffset, (BigInteger)(value), littleEndian);
		public void setBigUint64(uint byteOffset, UInt64 value) => Method().Invoke(byteOffset, (BigInteger)(value));
		public void setBigUint64(uint byteOffset, UInt64 value, bool littleEndian) => Method().Invoke(byteOffset, (BigInteger)(value), littleEndian);
	}
}
