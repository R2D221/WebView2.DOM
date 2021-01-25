using OneOf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace OneOf
{
	[DebuggerDisplay("{Value}")]
	public struct OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> : IEquatable<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		private readonly int index;
		private readonly T0 value0;
		private readonly T1 value1;
		private readonly T2 value2;
		private readonly T3 value3;
		private readonly T4 value4;
		private readonly T5 value5;
		private readonly T6 value6;
		private readonly T7 value7;
		private readonly T8 value8;

		OneOf(bool _)
		{
			index = default!;
			value0 = default!;
			value1 = default!;
			value2 = default!;
			value3 = default!;
			value4 = default!;
			value5 = default!;
			value6 = default!;
			value7 = default!;
			value8 = default!;
		}

		OneOf(T0 value) : this(false) => (index, value0) = (0, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T1 value) : this(false) => (index, value1) = (1, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T2 value) : this(false) => (index, value2) = (2, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T3 value) : this(false) => (index, value3) = (3, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T4 value) : this(false) => (index, value4) = (4, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T5 value) : this(false) => (index, value5) = (5, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T6 value) : this(false) => (index, value6) = (6, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T7 value) : this(false) => (index, value7) = (7, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T8 value) : this(false) => (index, value8) = (8, value ?? throw new ArgumentNullException(nameof(value)));

		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T1 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T2 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T3 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T7 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);
		public static implicit operator OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T8 t) => new OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t);

		public object? Value => index switch
		{
			0 => value0,
			1 => value1,
			2 => value2,
			3 => value3,
			4 => value4,
			5 => value5,
			6 => value6,
			7 => value7,
			8 => value8,
			_ => throw new InvalidOperationException(),
		};

		public bool Is([MaybeNullWhen(false)] out T0 value) { value = value0; return index == 0; }
		public bool Is([MaybeNullWhen(false)] out T1 value) { value = value1; return index == 1; }
		public bool Is([MaybeNullWhen(false)] out T2 value) { value = value2; return index == 2; }
		public bool Is([MaybeNullWhen(false)] out T3 value) { value = value3; return index == 3; }
		public bool Is([MaybeNullWhen(false)] out T4 value) { value = value4; return index == 4; }
		public bool Is([MaybeNullWhen(false)] out T5 value) { value = value5; return index == 5; }
		public bool Is([MaybeNullWhen(false)] out T6 value) { value = value6; return index == 6; }
		public bool Is([MaybeNullWhen(false)] out T7 value) { value = value7; return index == 7; }
		public bool Is([MaybeNullWhen(false)] out T8 value) { value = value8; return index == 8; }

		public void Switch
			(/**/Action<T0> f0
			,/**/Action<T1> f1
			,/**/Action<T2> f2
			,/**/Action<T3> f3
			,/**/Action<T4> f4
			,/**/Action<T5> f5
			,/**/Action<T6> f6
			,/**/Action<T7> f7
			,/**/Action<T8> f8
			)
		{
			switch (index)
			{
			case 0: f0(value0); break;
			case 1: f1(value1); break;
			case 2: f2(value2); break;
			case 3: f3(value3); break;
			case 4: f4(value4); break;
			case 5: f5(value5); break;
			case 6: f6(value6); break;
			case 7: f7(value7); break;
			case 8: f8(value8); break;
			default: throw new InvalidOperationException();
			}
		}

		public TResult Match<TResult>
			(/**/Func<T0, TResult> f0
			,/**/Func<T1, TResult> f1
			,/**/Func<T2, TResult> f2
			,/**/Func<T3, TResult> f3
			,/**/Func<T4, TResult> f4
			,/**/Func<T5, TResult> f5
			,/**/Func<T6, TResult> f6
			,/**/Func<T7, TResult> f7
			,/**/Func<T8, TResult> f8
			)
		{
			return index switch
			{
				0 => f0(value0),
				1 => f1(value1),
				2 => f2(value2),
				3 => f3(value3),
				4 => f4(value4),
				5 => f5(value5),
				6 => f6(value6),
				7 => f7(value7),
				8 => f8(value8),
				_ => throw new InvalidOperationException(),
			};
		}

		public override string ToString() => index switch
		{
			0 => value0?.ToString() ?? "",
			1 => value1?.ToString() ?? "",
			2 => value2?.ToString() ?? "",
			3 => value3?.ToString() ?? "",
			4 => value4?.ToString() ?? "",
			5 => value5?.ToString() ?? "",
			6 => value6?.ToString() ?? "",
			7 => value7?.ToString() ?? "",
			8 => value8?.ToString() ?? "",
			_ => throw new InvalidOperationException(),
		};

		public struct EqualityComparer : IEqualityComparer<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
		{
			public bool Equals(OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> x, OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> y) =>
				x.index == y.index
				&& x.index switch
				{
					0 => EqualityComparer<T0>.Default.Equals(x.value0, y.value0),
					1 => EqualityComparer<T1>.Default.Equals(x.value1, y.value1),
					2 => EqualityComparer<T2>.Default.Equals(x.value2, y.value2),
					3 => EqualityComparer<T3>.Default.Equals(x.value3, y.value3),
					4 => EqualityComparer<T4>.Default.Equals(x.value4, y.value4),
					5 => EqualityComparer<T5>.Default.Equals(x.value5, y.value5),
					6 => EqualityComparer<T6>.Default.Equals(x.value6, y.value6),
					7 => EqualityComparer<T7>.Default.Equals(x.value7, y.value7),
					8 => EqualityComparer<T8>.Default.Equals(x.value8, y.value8),
					_ => throw new InvalidOperationException(),
				};

			public int GetHashCode(OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> obj) =>
				obj.index switch
				{
					0 => (obj.index, obj.value0).GetHashCode(),
					1 => (obj.index, obj.value1).GetHashCode(),
					2 => (obj.index, obj.value2).GetHashCode(),
					3 => (obj.index, obj.value3).GetHashCode(),
					4 => (obj.index, obj.value4).GetHashCode(),
					5 => (obj.index, obj.value5).GetHashCode(),
					6 => (obj.index, obj.value6).GetHashCode(),
					7 => (obj.index, obj.value7).GetHashCode(),
					8 => (obj.index, obj.value8).GetHashCode(),
					_ => throw new InvalidOperationException(),
				};
		}

		#region IEquatable
		public override int GetHashCode() =>
			default(EqualityComparer).GetHashCode(this);

		public override bool Equals(object? other) => other is OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> that &&
			default(EqualityComparer).Equals(this, that);
		public bool Equals(OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> that) =>
			default(EqualityComparer).Equals(this, that);
		public static bool operator ==(OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> x, OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> y) =>
			default(EqualityComparer).Equals(x, y);
		public static bool operator !=(OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> x, OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> y) =>
			!default(EqualityComparer).Equals(x, y);
		#endregion
	}
}

public static partial class OneOfExtensions
{
	public static void Switch<T0, T1, T2, T3, T4, T5, T6, T7, T8>
		(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this
		,/**/Action<T0> f0
		,/**/Action<T1> f1
		,/**/Action<T2> f2
		,/**/Action<T3> f3
		,/**/Action<T4> f4
		,/**/Action<T5> f5
		,/**/Action<T6> f6
		,/**/Action<T7> f7
		,/**/Action<T8> f8
		,/**/Action<object?> fNull
		)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		switch (@this)
		{
		case null: fNull(null); break;
		case OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> x:
			x.Switch(f0, f1, f2, f3, f4, f5, f6, f7, f8);
			break;
		}
	}

	public static TResult Match<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
		(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this
		,/**/Func<T0, TResult> f0
		,/**/Func<T1, TResult> f1
		,/**/Func<T2, TResult> f2
		,/**/Func<T3, TResult> f3
		,/**/Func<T4, TResult> f4
		,/**/Func<T5, TResult> f5
		,/**/Func<T6, TResult> f6
		,/**/Func<T7, TResult> f7
		,/**/Func<T8, TResult> f8
		,/**/Func<object?, TResult> fNull
		)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		return @this switch
		{
			null => fNull(null),
			OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> x =>
				x.Match(f0, f1, f2, f3, f4, f5, f6, f7, f8),
		};
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T0 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T1 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T2 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T3 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T4 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T5 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T6 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T7 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>? @this, [MaybeNullWhen(false)] out T8 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}
}