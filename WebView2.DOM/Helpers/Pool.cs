using Microsoft.Extensions.ObjectPool;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	internal static class Pool
	{
		// based on PooledAwait.Pool
		// https://github.com/mgravell/PooledAwait/blob/master/src/PooledAwait/Pool.cs

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object Box<T>(in T value) where T : struct
			=> ItemBox<T>.Create(in value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T UnboxAndReturn<T>(object? obj) where T : struct
			=> ItemBox<T>.UnboxAndReturn(obj);

		internal sealed class ItemBox<T> where T : struct
		{
			private static readonly ObjectPool<ItemBox<T>> pool = new DefaultObjectPool<ItemBox<T>>(new DefaultPooledObjectPolicy<ItemBox<T>>());

			private T _value;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static ItemBox<T> Create(in T value)
			{
				var box = pool.Get();
				box._value = value;
				return box;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static T UnboxAndReturn(object? obj)
			{
				var box = (ItemBox<T>)obj!;
				var value = box._value;
				box._value = default;
				pool.Return(box);
				return value;
			}
		}
	}
}
