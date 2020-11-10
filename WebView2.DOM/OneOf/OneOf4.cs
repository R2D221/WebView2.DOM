﻿using Require;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OneOf
{
	[DebuggerDisplay("{Value}")]
	public struct OneOf<T0, T1, T2, T3> : IEquatable<OneOf<T0, T1, T2, T3>>
	{
		private readonly int index;
		private readonly T0 value0;
		private readonly T1 value1;
		private readonly T2 value2;
		private readonly T3 value3;

		OneOf(bool _)
		{
			index = default!;
			value0 = default!;
			value1 = default!;
			value2 = default!;
			value3 = default!;
		}

		OneOf(T0 value) : this(false) => (index, value0) = (0, value);
		OneOf(T1 value) : this(false) => (index, value1) = (1, value);
		OneOf(T2 value) : this(false) => (index, value2) = (2, value);
		OneOf(T3 value) : this(false) => (index, value3) = (3, value);

		public static implicit operator OneOf<T0, T1, T2, T3>(T0 t) => new OneOf<T0, T1, T2, T3>(t);
		public static implicit operator OneOf<T0, T1, T2, T3>(T1 t) => new OneOf<T0, T1, T2, T3>(t);
		public static implicit operator OneOf<T0, T1, T2, T3>(T2 t) => new OneOf<T0, T1, T2, T3>(t);
		public static implicit operator OneOf<T0, T1, T2, T3>(T3 t) => new OneOf<T0, T1, T2, T3>(t);

		public object? Value => index switch
		{
			0 => value0,
			1 => value1,
			2 => value2,
			3 => value3,
			_ => throw new InvalidOperationException(),
		};

		public bool Is<T>(Type<T0> _ = default!) where T : T0 => index == 0;
		public bool Is<T>(Type<T1> _ = default!) where T : T1 => index == 1;
		public bool Is<T>(Type<T2> _ = default!) where T : T2 => index == 2;
		public bool Is<T>(Type<T3> _ = default!) where T : T3 => index == 3;

		public T0 As<T>(Type<T0> _ = default!) where T : T0 => value0;
		public T1 As<T>(Type<T1> _ = default!) where T : T1 => value1;
		public T2 As<T>(Type<T2> _ = default!) where T : T2 => value2;
		public T3 As<T>(Type<T3> _ = default!) where T : T3 => value3;

		public void Switch
			(/**/Action<T0> f0
			,/**/Action<T1> f1
			,/**/Action<T2> f2
			,/**/Action<T3> f3
			)
		{
			switch (index)
			{
			case 0: f0(value0); break;
			case 1: f1(value1); break;
			case 2: f2(value2); break;
			case 3: f3(value3); break;
			default: throw new InvalidOperationException();
			}
		}

		public TResult Match<TResult>
			(/**/Func<T0, TResult> f0
			,/**/Func<T1, TResult> f1
			,/**/Func<T2, TResult> f2
			,/**/Func<T3, TResult> f3
			)
		{
			return index switch
			{
				0 => f0(value0),
				1 => f1(value1),
				2 => f2(value2),
				3 => f3(value3),
				_ => throw new InvalidOperationException(),
			};
		}

		public OneOf<MapT0, T1, T2, T3> Map<T, MapT0>(Func<T, MapT0> mapFunc, Type<T0> _ = default!) where T : T0 => Match<OneOf<MapT0, T1, T2, T3>>(_0 => mapFunc((T)_0!), _1 => _1, _2 => _2, _3 => _3);
		public OneOf<T0, MapT1, T2, T3> Map<T, MapT1>(Func<T, MapT1> mapFunc, Type<T1> _ = default!) where T : T1 => Match<OneOf<T0, MapT1, T2, T3>>(_0 => _0, _1 => mapFunc((T)_1!), _2 => _2, _3 => _3);
		public OneOf<T0, T1, MapT2, T3> Map<T, MapT2>(Func<T, MapT2> mapFunc, Type<T2> _ = default!) where T : T2 => Match<OneOf<T0, T1, MapT2, T3>>(_0 => _0, _1 => _1, _2 => mapFunc((T)_2!), _3 => _3);
		public OneOf<T0, T1, T2, MapT3> Map<T, MapT3>(Func<T, MapT3> mapFunc, Type<T3> _ = default!) where T : T3 => Match<OneOf<T0, T1, T2, MapT3>>(_0 => _0, _1 => _1, _2 => _2, _3 => mapFunc((T)_3!));

		public bool TryPick<T>(out T value, out OneOf<T1, T2, T3> remainder, Type<T0> _ = default!) where T : T0 { var @is = Is<T0>(); value = @is ? (T)As<T0>()! : default!; remainder = @is ? default! : Match<OneOf<T1, T2, T3>>(_0 => throw new InvalidOperationException(), _1 => _1, _2 => _2, _3 => _3); return @is; }
		public bool TryPick<T>(out T value, out OneOf<T0, T2, T3> remainder, Type<T1> _ = default!) where T : T1 { var @is = Is<T1>(); value = @is ? (T)As<T1>()! : default!; remainder = @is ? default! : Match<OneOf<T0, T2, T3>>(_0 => _0, _1 => throw new InvalidOperationException(), _2 => _2, _3 => _3); return @is; }
		public bool TryPick<T>(out T value, out OneOf<T0, T1, T3> remainder, Type<T2> _ = default!) where T : T2 { var @is = Is<T2>(); value = @is ? (T)As<T2>()! : default!; remainder = @is ? default! : Match<OneOf<T0, T1, T3>>(_0 => _0, _1 => _1, _2 => throw new InvalidOperationException(), _3 => _3); return @is; }
		public bool TryPick<T>(out T value, out OneOf<T0, T1, T2> remainder, Type<T3> _ = default!) where T : T3 { var @is = Is<T3>(); value = @is ? (T)As<T3>()! : default!; remainder = @is ? default! : Match<OneOf<T0, T1, T2>>(_0 => _0, _1 => _1, _2 => _2, _3 => throw new InvalidOperationException()); return @is; }

		public override string ToString() => index switch
		{
			0 => value0?.ToString() ?? "",
			1 => value1?.ToString() ?? "",
			2 => value2?.ToString() ?? "",
			3 => value3?.ToString() ?? "",
			_ => throw new InvalidOperationException(),
		};

		public struct EqualityComparer : IEqualityComparer<OneOf<T0, T1, T2, T3>>
		{
			public bool Equals(OneOf<T0, T1, T2, T3> x, OneOf<T0, T1, T2, T3> y) =>
				x.index == y.index
				&& x.index switch
				{
					0 => EqualityComparer<T0>.Default.Equals(x.value0, y.value0),
					1 => EqualityComparer<T1>.Default.Equals(x.value1, y.value1),
					2 => EqualityComparer<T2>.Default.Equals(x.value2, y.value2),
					3 => EqualityComparer<T3>.Default.Equals(x.value3, y.value3),
					_ => throw new InvalidOperationException(),
				};

			public int GetHashCode(OneOf<T0, T1, T2, T3> obj) =>
				obj.index switch
				{
					0 => (obj.index, obj.value0).GetHashCode(),
					1 => (obj.index, obj.value1).GetHashCode(),
					2 => (obj.index, obj.value2).GetHashCode(),
					3 => (obj.index, obj.value3).GetHashCode(),
					_ => throw new InvalidOperationException(),
				};
		}

		#region IEquatable
		public override int GetHashCode() =>
			default(EqualityComparer).GetHashCode(this);

		public override bool Equals(object? other) => other is OneOf<T0, T1, T2, T3> that &&
			default(EqualityComparer).Equals(this, that);
		public bool Equals(OneOf<T0, T1, T2, T3> that) =>
			default(EqualityComparer).Equals(this, that);
		public static bool operator ==(OneOf<T0, T1, T2, T3> x, OneOf<T0, T1, T2, T3> y) =>
			default(EqualityComparer).Equals(x, y);
		public static bool operator !=(OneOf<T0, T1, T2, T3> x, OneOf<T0, T1, T2, T3> y) =>
			!default(EqualityComparer).Equals(x, y);
		#endregion
	}
}