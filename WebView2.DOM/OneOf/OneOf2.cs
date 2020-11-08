using Require;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OneOf
{
	[DebuggerDisplay("{Value}")]
	public struct OneOf<T0, T1> : IEquatable<OneOf<T0, T1>>
	{
		private readonly int index;
		private readonly T0 value0;
		private readonly T1 value1;

		OneOf(bool _)
		{
			index = default!;
			value0 = default!;
			value1 = default!;
		}

		OneOf(T0 value) : this(false) => (index, value0) = (0, value);
		OneOf(T1 value) : this(false) => (index, value1) = (1, value);

		public static implicit operator OneOf<T0, T1>(T0 t) => new OneOf<T0, T1>(t);
		public static implicit operator OneOf<T0, T1>(T1 t) => new OneOf<T0, T1>(t);

		public object? Value => index switch
		{
			0 => value0,
			1 => value1,
			_ => throw new InvalidOperationException(),
		};

		public bool Is<T>(Type<T0> _ = default!) where T : T0 => index == 0;
		public bool Is<T>(Type<T1> _ = default!) where T : T1 => index == 1;

		public T0 As<T>(Type<T0> _ = default!) where T : T0 => value0;
		public T1 As<T>(Type<T1> _ = default!) where T : T1 => value1;

		public void Switch
			(/**/Action<T0> f0
			,/**/Action<T1> f1
			)
		{
			switch (index)
			{
			case 0: f0(value0); break;
			case 1: f1(value1); break;
			default: throw new InvalidOperationException();
			}
		}

		public TResult Match<TResult>
			(/**/Func<T0, TResult> f0
			,/**/Func<T1, TResult> f1
			)
		{
			return index switch
			{
				0 => f0(value0),
				1 => f1(value1),
				_ => throw new InvalidOperationException(),
			};
		}

		public OneOf<MapT0, T1> Map<T, MapT0>(Func<T, MapT0> mapFunc, Type<T0> _ = default!) where T : T0 => Match<OneOf<MapT0, T1>>(_0 => mapFunc((T)_0!), _1 => _1);
		public OneOf<T0, MapT1> Map<T, MapT1>(Func<T, MapT1> mapFunc, Type<T1> _ = default!) where T : T1 => Match<OneOf<T0, MapT1>>(_0 => _0, _1 => mapFunc((T)_1!));

		public bool TryPick<T>(out T value, out T1 remainder, Type<T0> _ = default!) where T : T0 { var @is = Is<T0>(); value = @is ? (T)As<T0>()! : default!; remainder = @is ? default! : Match<T1>(_0 => throw new InvalidOperationException(), _1 => _1); return @is; }
		public bool TryPick<T>(out T value, out T0 remainder, Type<T1> _ = default!) where T : T1 { var @is = Is<T1>(); value = @is ? (T)As<T1>()! : default!; remainder = @is ? default! : Match<T0>(_0 => _0, _1 => throw new InvalidOperationException()); return @is; }

		public override string ToString() => index switch
		{
			0 => value0?.ToString() ?? "",
			1 => value1?.ToString() ?? "",
			_ => throw new InvalidOperationException(),
		};

		public struct EqualityComparer : IEqualityComparer<OneOf<T0, T1>>
		{
			public bool Equals(OneOf<T0, T1> x, OneOf<T0, T1> y) =>
				x.index == y.index
				&& x.index switch
				{
					0 => EqualityComparer<T0>.Default.Equals(x.value0, y.value0),
					1 => EqualityComparer<T1>.Default.Equals(x.value1, y.value1),
					_ => throw new InvalidOperationException(),
				};

			public int GetHashCode(OneOf<T0, T1> obj) =>
				obj.index switch
				{
					0 => (obj.index, obj.value0).GetHashCode(),
					1 => (obj.index, obj.value1).GetHashCode(),
					_ => throw new InvalidOperationException(),
				};
		}

		#region IEquatable
		public override int GetHashCode() =>
			default(EqualityComparer).GetHashCode(this);

		public override bool Equals(object? other) => other is OneOf<T0, T1> that &&
			default(EqualityComparer).Equals(this, that);
		public bool Equals(OneOf<T0, T1> that) =>
			default(EqualityComparer).Equals(this, that);
		public static bool operator ==(OneOf<T0, T1> x, OneOf<T0, T1> y) =>
			default(EqualityComparer).Equals(x, y);
		public static bool operator !=(OneOf<T0, T1> x, OneOf<T0, T1> y) =>
			!default(EqualityComparer).Equals(x, y);
		#endregion
	}
}
