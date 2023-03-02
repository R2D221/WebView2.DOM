using System.Collections.Concurrent;
using System;
using Microsoft.Extensions.ObjectPool;

namespace WebView2.DOM
{
	internal static class ObjectArrayPool
	{
		public class ObjectArrayPooledObjectPolicy : PooledObjectPolicy<object?[]>
		{
			private readonly int length;

			public ObjectArrayPooledObjectPolicy(int length)
			{
				this.length = length;
			}

			public override object?[] Create() => new object?[length];

			public override bool Return(object?[] obj)
			{
				Array.Clear(obj, 0, obj.Length);
				return true;
			}
		}

		public ref struct Entry
		{
			private bool disposedValue;

			private object?[] array;
			private ObjectPool<object?[]> pool;

			internal Entry(object?[] array, ObjectPool<object?[]> pool)
			{
				this.array = array;
				this.pool = pool;
			}

			public object?[] Array => disposedValue ? throw new ObjectDisposedException("Entry") : array;

			public void Dispose()
			{
				if (!disposedValue)
				{
					pool.Return(array);

					array = null!;
					pool = null!;

					disposedValue = true;
				}
			}
		}


		private static ConcurrentDictionary<int, ObjectPool<object?[]>> lengthsDict = new();

		public static Entry Get(int length)
		{
			var pool = lengthsDict.GetOrAdd(length, _length => new DefaultObjectPool<object?[]>(new ObjectArrayPooledObjectPolicy(_length)));
			var array = pool.Get();
			return new Entry(array, pool);
		}
	}
}