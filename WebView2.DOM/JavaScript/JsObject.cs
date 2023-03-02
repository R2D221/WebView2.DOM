using OverloadResolution;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public class JsObject
	{
		private protected JsObject() { }

		private protected static JsExecutionContext.CSharpSide executionContext =>
			BrowsingContext.Current.RunningExecutionContext?.CSharp
			??
			throw new InvalidOperationException();

		internal void Construct()
		{
			executionContext.Construct(this, GetType().Name, Array.Empty<object?>());
		}

		#region Construct<T0>

		internal void Construct<T0>(T0 arg0, RequireStruct<T0>? _ = null)
			where T0 : struct
		{
			using var args = ObjectArrayPool.Get(1);
			using var x0 = Pool.Box(arg0);

			args.Array[0] = x0.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0>(T0? arg0, RequireStruct<T0>? _ = null)
			where T0 : struct
		{
			using var args = ObjectArrayPool.Get(1);
			using var x0 = Pool.Box(arg0);

			args.Array[0] = x0.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0>(T0? arg0, RequireNullableClass<T0>? _ = null)
			where T0 : class?
		{
			using var args = ObjectArrayPool.Get(1);

			args.Array[0] = arg0;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		#endregion

		#region Construct<T0, T1>

		internal void Construct<T0, T1>(T0 arg0, T1 arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
			where T0 : struct
			where T1 : struct
		{
			using var args = ObjectArrayPool.Get(2);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0? arg0, T1 arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
			where T0 : struct
			where T1 : struct
		{
			using var args = ObjectArrayPool.Get(2);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0? arg0, T1 arg1, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null)
			where T0 : class?
			where T1 : struct
		{
			using var args = ObjectArrayPool.Get(2);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0 arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
			where T0 : struct
			where T1 : struct
		{
			using var args = ObjectArrayPool.Get(2);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0? arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
			where T0 : struct
			where T1 : struct
		{
			using var args = ObjectArrayPool.Get(2);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0? arg0, T1? arg1, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null)
			where T0 : class?
			where T1 : struct
		{
			using var args = ObjectArrayPool.Get(2);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0 arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null)
			where T0 : struct
			where T1 : class?
		{
			using var args = ObjectArrayPool.Get(2);
			using var x0 = Pool.Box(arg0);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0? arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null)
			where T0 : struct
			where T1 : class?
		{
			using var args = ObjectArrayPool.Get(2);
			using var x0 = Pool.Box(arg0);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1>(T0? arg0, T1? arg1, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null)
			where T0 : class?
			where T1 : class?
		{
			using var args = ObjectArrayPool.Get(2);

			args.Array[0] = arg0;
			args.Array[1] = arg1;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		#endregion

		#region Construct<T0, T1, T2>

		internal void Construct<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1 arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1 arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : class?
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : class?
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : class?
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : class?
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : class?
			where T1 : class?
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = arg0;
			args.Array[1] = arg1;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : class?
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : class?
			where T1 : struct
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : class?
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : struct
			where T1 : class?
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
			where T0 : class?
			where T1 : class?
			where T2 : struct
		{
			using var args = ObjectArrayPool.Get(3);
			using var x2 = Pool.Box(arg2);

			args.Array[0] = arg0;
			args.Array[1] = arg1;
			args.Array[2] = x2.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : class?
			where T1 : struct
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : struct
			where T1 : struct
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : class?
			where T1 : struct
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x1 = Pool.Box(arg1);

			args.Array[0] = arg0;
			args.Array[1] = x1.Obj;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : struct
			where T1 : class?
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : struct
			where T1 : class?
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);
			using var x0 = Pool.Box(arg0);

			args.Array[0] = x0.Obj;
			args.Array[1] = arg1;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
			where T0 : class?
			where T1 : class?
			where T2 : class?
		{
			using var args = ObjectArrayPool.Get(3);

			args.Array[0] = arg0;
			args.Array[1] = arg1;
			args.Array[2] = arg2;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		#endregion

		#region Construct<T0, T1, T2, T3>

		internal void Construct<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null, RequireStruct<T3>? ____ = null)
			where T0 : struct
			where T1 : struct
			where T2 : struct
			where T3 : struct
		{
			using var args = ObjectArrayPool.Get(4);
			using var x0 = Pool.Box(arg0);
			using var x1 = Pool.Box(arg1);
			using var x2 = Pool.Box(arg2);
			using var x3 = Pool.Box(arg3);

			args.Array[0] = x0.Obj;
			args.Array[1] = x1.Obj;
			args.Array[2] = x2.Obj;
			args.Array[3] = x3.Obj;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		internal void Construct<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null, RequireNullableClass<T3>? ____ = null)
			where T0 : class?
			where T1 : class?
			where T2 : class?
			where T3 : class?
		{
			using var args = ObjectArrayPool.Get(4);

			args.Array[0] = arg0;
			args.Array[1] = arg1;
			args.Array[2] = arg2;
			args.Array[3] = arg3;

			executionContext.Construct(this, GetType().Name, args.Array);
		}

		#endregion

		internal void Construct<TArgs>(TArgs[] args)
			where TArgs : class?
		{
			using var objArgs = ObjectArrayPool.Get(args.Length);

			Array.Copy(args, objArgs.Array, args.Length);

			executionContext.Construct(this, GetType().Name, objArgs.Array);
		}

		private static class Cache<T>
		{
			public static ConditionalWeakTable<JsObject, ConcurrentDictionary<string, T>> caches = new();
		}

		internal T GetCached<T>([CallerMemberName] string property = "")
		{
			return Cache<T>.caches
				.GetValue(this, _ => new())
				.GetOrAdd(property, _property => Get<T>(_property));
		}

		internal T Get<T>([CallerMemberName] string property = "")
		{
			return executionContext.Get<T>(this, property);
		}

		internal void Set<T>(T value, [CallerMemberName] string property = "")
		{
			executionContext.Set(this, property, value);
		}

		internal T IndexerGet<T>(string index)
		{
			return executionContext.Get<T>(this, index);
		}

		internal T IndexerGet<T>(uint index)
		{
			return executionContext.Get<T>(this, index);
		}

		internal T IndexerGet<T>(int index)
		{
			return executionContext.Get<T>(this, index);
		}

		internal void IndexerSet<T>(string index, T value)
		{
			executionContext.Set(this, index, value);
		}

		internal void IndexerSet<T>(uint index, T value)
		{
			executionContext.Set(this, index, value);
		}

		internal void IndexerSet<T>(int index, T value)
		{
			executionContext.Set(this, index, value);
		}

		internal void IndexerDelete(string index)
		{
			executionContext.Delete(this, index);
		}

		internal void IndexerDelete(uint index)
		{
			executionContext.Delete(this, index);
		}

		internal void IndexerDelete(int index)
		{
			executionContext.Delete(this, index);
		}

		internal Invoker Method([CallerMemberName] string method = "")
			=> new Invoker(this, method);

		internal readonly ref struct Invoker
		{
			public Invoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			internal void Invoke()
			{
				executionContext.InvokeVoid(@this, method, Array.Empty<object?>());
			}

			#region Invoke<T0>

			internal void Invoke<T0>(T0 arg0, RequireStruct<T0>? _ = null)
				where T0 : struct
			{
				using var args = ObjectArrayPool.Get(1);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0>(T0? arg0, RequireStruct<T0>? _ = null)
				where T0 : struct
			{
				using var args = ObjectArrayPool.Get(1);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0>(T0? arg0, RequireNullableClass<T0>? _ = null)
				where T0 : class?
			{
				using var args = ObjectArrayPool.Get(1);

				args.Array[0] = arg0;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1>

			internal void Invoke<T0, T1>(T0 arg0, T1 arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0? arg0, T1 arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0? arg0, T1 arg1, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : class?
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0 arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0? arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0? arg0, T1? arg1, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : class?
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0 arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null)
				where T0 : struct
				where T1 : class?
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0? arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null)
				where T0 : struct
				where T1 : class?
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1>(T0? arg0, T1? arg1, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null)
				where T0 : class?
				where T1 : class?
			{
				using var args = ObjectArrayPool.Get(2);

				args.Array[0] = arg0;
				args.Array[1] = arg1;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1, T2>

			internal void Invoke<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : class?
				where T1 : class?
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);

				args.Array[0] = arg0;
				args.Array[1] = arg1;
				args.Array[2] = arg2;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1, T2, T3>

			//internal void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null, RequireStruct<T3>? ____ = null)
			//	where T0 : struct
			//	where T1 : struct
			//	where T2 : struct
			//	where T3 : struct
			//{
			//	using var args = ObjectArrayPool.Get(4);
			//	using var x0 = Pool.Box(arg0);
			//	using var x1 = Pool.Box(arg1);
			//	using var x2 = Pool.Box(arg2);
			//	using var x3 = Pool.Box(arg3);

			//	args.Array[0] = x0.Obj;
			//	args.Array[1] = x1.Obj;
			//	args.Array[2] = x2.Obj;
			//	args.Array[3] = x3.Obj;

			//	executionContext.InvokeVoid(@this, method, args.Array);
			//}

			internal void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null, RequireStruct<T3>? ____ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
				where T3 : struct
			{
				using var args = ObjectArrayPool.Get(4);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);
				using var x3 = Pool.Box(arg3);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;
				args.Array[3] = x3.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			internal void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null, RequireStruct<T3>? ____ = null)
				where T0 : class?
				where T1 : struct
				where T2 : class?
				where T3 : struct
			{
				using var args = ObjectArrayPool.Get(4);
				using var x1 = Pool.Box(arg1);
				using var x3 = Pool.Box(arg3);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;
				args.Array[3] = x3.Obj;

				executionContext.InvokeVoid(@this, method, args.Array);
			}

			//internal void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null, RequireNullableClass<T3>? ____ = null)
			//	where T0 : class?
			//	where T1 : class?
			//	where T2 : class?
			//	where T3 : class?
			//{
			//	using var args = ObjectArrayPool.Get(4);

			//	args.Array[0] = arg0;
			//	args.Array[1] = arg1;
			//	args.Array[2] = arg2;
			//	args.Array[3] = arg3;

			//	executionContext.InvokeVoid(@this, method, args.Array);
			//}

			#endregion

			internal void Invoke<TArgs>(TArgs[] args)
				where TArgs : class?
			{
				using var objArgs = ObjectArrayPool.Get(args.Length);

				Array.Copy(args, objArgs.Array, args.Length);

				executionContext.InvokeVoid(@this, method, objArgs.Array);
			}

		}

		internal Invoker<T> Method<T>([CallerMemberName] string method = "")
			=> new Invoker<T>(this, method);

		internal readonly ref struct Invoker<T>
		{
			public Invoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			internal T Invoke()
			{
				return executionContext.Invoke<T>(@this, method, Array.Empty<object?>());
			}

			#region Invoke<T0>

			internal T Invoke<T0>(T0 arg0, RequireStruct<T0>? _ = null)
				where T0 : struct
			{
				using var args = ObjectArrayPool.Get(1);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0>(T0? arg0, RequireStruct<T0>? _ = null)
				where T0 : struct
			{
				using var args = ObjectArrayPool.Get(1);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0>(T0? arg0, RequireNullableClass<T0>? _ = null)
				where T0 : class?
			{
				using var args = ObjectArrayPool.Get(1);

				args.Array[0] = arg0;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1>

			internal T Invoke<T0, T1>(T0 arg0, T1 arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0? arg0, T1 arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0? arg0, T1 arg1, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : class?
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0 arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0? arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : struct
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0? arg0, T1? arg1, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null)
				where T0 : class?
				where T1 : struct
			{
				using var args = ObjectArrayPool.Get(2);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0 arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null)
				where T0 : struct
				where T1 : class?
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0? arg0, T1? arg1, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null)
				where T0 : struct
				where T1 : class?
			{
				using var args = ObjectArrayPool.Get(2);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1>(T0? arg0, T1? arg1, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null)
				where T0 : class?
				where T1 : class?
			{
				using var args = ObjectArrayPool.Get(2);

				args.Array[0] = arg0;
				args.Array[1] = arg1;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1, T2>

			internal T Invoke<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2 arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireStruct<T2>? ___ = null)
				where T0 : class?
				where T1 : class?
				where T2 : struct
			{
				using var args = ObjectArrayPool.Get(3);
				using var x2 = Pool.Box(arg2);

				args.Array[0] = arg0;
				args.Array[1] = arg1;
				args.Array[2] = x2.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1 arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : class?
				where T1 : struct
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x1 = Pool.Box(arg1);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0 arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireStruct<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : struct
				where T1 : class?
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);
				using var x0 = Pool.Box(arg0);

				args.Array[0] = x0.Obj;
				args.Array[1] = arg1;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2>(T0? arg0, T1? arg1, T2? arg2, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null)
				where T0 : class?
				where T1 : class?
				where T2 : class?
			{
				using var args = ObjectArrayPool.Get(3);

				args.Array[0] = arg0;
				args.Array[1] = arg1;
				args.Array[2] = arg2;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1, T2, T3>

			internal T Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null, RequireStruct<T3>? ____ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
				where T3 : struct
			{
				using var args = ObjectArrayPool.Get(4);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);
				using var x3 = Pool.Box(arg3);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;
				args.Array[3] = x3.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			//internal void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null, RequireNullableClass<T3>? ____ = null)
			//	where T0 : class?
			//	where T1 : class?
			//	where T2 : class?
			//	where T3 : class?
			//{
			//	using var args = ObjectArrayPool.Get(4);

			//	args.Array[0] = arg0;
			//	args.Array[1] = arg1;
			//	args.Array[2] = arg2;
			//	args.Array[3] = arg3;

			//	executionContext.InvokeVoid(@this, method, args.Array);
			//}

			#endregion

			#region Invoke<T0, T1, T2, T3, T4>

			internal T Invoke<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null, RequireStruct<T3>? ____ = null, RequireStruct<T4>? _____ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
				where T3 : struct
				where T4 : struct
			{
				using var args = ObjectArrayPool.Get(5);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);
				using var x3 = Pool.Box(arg3);
				using var x4 = Pool.Box(arg4);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;
				args.Array[3] = x3.Obj;
				args.Array[4] = x4.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			internal T Invoke<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, RequireNullableClass<T0>? _ = null, RequireNullableClass<T1>? __ = null, RequireNullableClass<T2>? ___ = null, RequireStruct<T3>? ____ = null, RequireNullableClass<T4>? _____ = null)
				where T0 : class?
				where T1 : class?
				where T2 : class?
				where T3 : struct
				where T4 : class?
			{
				using var args = ObjectArrayPool.Get(5);
				using var x3 = Pool.Box(arg3);

				args.Array[0] = arg0;
				args.Array[1] = arg1;
				args.Array[2] = arg2;
				args.Array[3] = x3.Obj;
				args.Array[4] = arg4;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1, T2, T3, T4, T5>

			internal T Invoke<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, RequireStruct<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null, RequireStruct<T3>? ____ = null, RequireStruct<T4>? _____ = null, RequireStruct<T5>? ______ = null)
				where T0 : struct
				where T1 : struct
				where T2 : struct
				where T3 : struct
				where T4 : struct
				where T5 : struct
			{
				using var args = ObjectArrayPool.Get(6);
				using var x0 = Pool.Box(arg0);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);
				using var x3 = Pool.Box(arg3);
				using var x4 = Pool.Box(arg4);
				using var x5 = Pool.Box(arg5);

				args.Array[0] = x0.Obj;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;
				args.Array[3] = x3.Obj;
				args.Array[4] = x4.Obj;
				args.Array[5] = x5.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			#endregion

			#region Invoke<T0, T1, T2, T3, T4, T5, T6>

			internal T Invoke<T0, T1, T2, T3, T4, T5, T6>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, RequireNullableClass<T0>? _ = null, RequireStruct<T1>? __ = null, RequireStruct<T2>? ___ = null, RequireStruct<T3>? ____ = null, RequireStruct<T4>? _____ = null, RequireStruct<T5>? ______ = null, RequireStruct<T6>? _______ = null)
				where T0 : class?
				where T1 : struct
				where T2 : struct
				where T3 : struct
				where T4 : struct
				where T5 : struct
				where T6 : struct
			{
				using var args = ObjectArrayPool.Get(7);
				using var x1 = Pool.Box(arg1);
				using var x2 = Pool.Box(arg2);
				using var x3 = Pool.Box(arg3);
				using var x4 = Pool.Box(arg4);
				using var x5 = Pool.Box(arg5);
				using var x6 = Pool.Box(arg6);

				args.Array[0] = arg0;
				args.Array[1] = x1.Obj;
				args.Array[2] = x2.Obj;
				args.Array[3] = x3.Obj;
				args.Array[4] = x4.Obj;
				args.Array[5] = x5.Obj;
				args.Array[6] = x6.Obj;

				return executionContext.Invoke<T>(@this, method, args.Array);
			}

			#endregion

			internal T Invoke<TArgs>(TArgs[] args)
				where TArgs : class?
			{
				using var objArgs = ObjectArrayPool.Get(args.Length);

				Array.Copy(args, objArgs.Array, args.Length);

				return executionContext.Invoke<T>(@this, method, objArgs.Array);
			}
		}

		internal SymbolInvoker<T> SymbolMethod<T>([CallerMemberName] string method = "")
			=> new SymbolInvoker<T>(this, method);

		internal readonly ref struct SymbolInvoker<T>
		{
			public SymbolInvoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			internal T Invoke()
			{
				return executionContext.SymbolInvoke<T>(@this, method, Array.Empty<object?>());
			}

			internal T Invoke<TArgs>(TArgs[] args)
				where TArgs : class?
			{
				using var objArgs = ObjectArrayPool.Get(args.Length);

				Array.Copy(args, objArgs.Array, args.Length);

				return executionContext.SymbolInvoke<T>(@this, method, objArgs.Array);
			}
		}

		//private static class Static
		//{
		//	private static string GetTypeName()
		//	{
		//		var trace = new StackTrace();

		//		for (var i = 0; i < trace.FrameCount; i++)
		//		{
		//			var frame = trace.GetFrame(i);
		//			var type = frame?.GetMethod()?.DeclaringType;
		//			if (type == typeof(Static) || type == typeof(JsObject))
		//			{
		//				continue;
		//			}
		//			else if (type is not null)
		//			{
		//				return type.Name;
		//			}
		//		}

		//		throw new Exception("Type name not found");
		//	}

		//	public static JsObject Instance =>
		//		window.Instance.GetCached<JsObject>(GetTypeName());
		//}

		//internal static Invoker StaticMethod([CallerMemberName] string method = "") =>
		//	Static.Instance.Method(method);

		//internal static Invoker<T> StaticMethod<T>([CallerMemberName] string method = "") =>
		//	Static.Instance.Method<T>(method);
	}
}
