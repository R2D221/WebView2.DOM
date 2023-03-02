using Microsoft.Extensions.ObjectPool;
using OverloadResolution;
using System;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	internal static class Pool
	{
		// based on PooledAwait.Pool
		// https://github.com/mgravell/PooledAwait/blob/master/src/PooledAwait/Pool.cs


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static StructEntry<T> Box<T>(in T value, RequireStruct<T>? _ = null) where T : struct
			=>
			StructBox<T>.Create(in value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static NullableStructEntry<T> Box<T>(in T? value, RequireStruct<T>? _ = null) where T : struct
			=>
			StructBox<T>.CreateNullable(in value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T UnboxAndReturn<T>(object? obj) where T : struct
			=>
			StructBox<T>.UnboxAndReturn(obj);

		internal sealed class StructBox<T> where T : struct
		{
			private static readonly ObjectPool<object> pool = new DefaultObjectPool<object>(new StructPooledObjectPolicy<T>());

			private StructBox() { }

			public T Value;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static StructEntry<T> Create(in T value)
			{
				var obj = pool.Get();
				var box = Unsafe.As<StructBox<T>>(obj);
				box.Value = value;
				return new StructEntry<T>(obj, pool);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static NullableStructEntry<T> CreateNullable(in T? nullableValue)
			{
				if (nullableValue is {/*notnull*/} value)
				{
					var obj = pool.Get();
					var box = Unsafe.As<StructBox<T>>(obj);
					box.Value = value;
					return new NullableStructEntry<T>(obj, pool);
				}
				else
				{
					return new NullableStructEntry<T>(null, pool);
				}

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static T UnboxAndReturn(object? obj)
			{
				if (obj?.GetType() != typeof(T)) { throw new InvalidCastException(); }

				var box = Unsafe.As<StructBox<T>>(obj);
				var value = box.Value;
				box.Value = default;
				pool.Return(obj);
				return value;
			}
		}

		public class StructPooledObjectPolicy<T> : DefaultPooledObjectPolicy<object> where T : struct
		{
			public override object Create() => default(T);
		}

		internal ref struct StructEntry<T> where T : struct
		{
			private bool disposedValue;
			private object obj;
			private ObjectPool<object> pool;

			public StructEntry(object obj, ObjectPool<object> pool)
			{
				this.obj = obj;
				this.pool = pool;
			}

			public object Obj => disposedValue ? throw new ObjectDisposedException("Entry") : obj;

			public void Dispose()
			{
				if (!disposedValue)
				{
					Unsafe.As<StructBox<T>>(obj).Value = default;
					pool.Return(obj);

					obj = null!;
					pool = null!;

					disposedValue = true;
				}
			}
		}

		internal ref struct NullableStructEntry<T> where T : struct
		{
			private bool disposedValue;
			private object? obj;
			private ObjectPool<object> pool;

			public NullableStructEntry(object? obj, ObjectPool<object> pool)
			{
				this.obj = obj;
				this.pool = pool;
			}

			public object? Obj => disposedValue ? throw new ObjectDisposedException("Entry") : obj;

			public void Dispose()
			{
				if (!disposedValue)
				{
					if (obj is not null)
					{
						Unsafe.As<StructBox<T>>(obj).Value = default;
						pool.Return(obj);
					}

					obj = null!;
					pool = null!;

					disposedValue = true;
				}
			}
		}
	}
}

namespace OverloadResolution
{
	/// <summary>
	/// Helper class for resolving an overloaded method based on type parameter.
	/// </summary>
	/// <typeparam name="T">The type required</typeparam>
	public sealed class RequireType<T> { private RequireType() { } }

	/// <summary>
	/// Helper class for resolving an overloaded method based on type parameter.
	/// </summary>
	/// <typeparam name="T">The class required</typeparam>
	public sealed class RequireClass<T> where T : class { private RequireClass() { } }

	/// <summary>
	/// Helper class for resolving an overloaded method based on type parameter.
	/// </summary>
	/// <typeparam name="T">The class required</typeparam>
	public sealed class RequireNullableClass<T> where T : class? { private RequireNullableClass() { } }

	/// <summary>
	/// Helper class for resolving an overloaded method based on type parameter.
	/// </summary>
	/// <typeparam name="T">The struct required</typeparam>
	public sealed class RequireStruct<T> where T : struct { private RequireStruct() { } }
}
