using OneOf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace OneOf
{
	[DebuggerDisplay("{Value}")]
	public struct OneOf<T0, T1, T2, T3> : IEquatable<OneOf<T0, T1, T2, T3>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
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

		OneOf(T0 value) : this(false) => (index, value0) = (0, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T1 value) : this(false) => (index, value1) = (1, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T2 value) : this(false) => (index, value2) = (2, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T3 value) : this(false) => (index, value3) = (3, value ?? throw new ArgumentNullException(nameof(value)));

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

		public bool Is([MaybeNullWhen(false)] out T0 value) { value = value0; return index == 0; }
		public bool Is([MaybeNullWhen(false)] out T1 value) { value = value1; return index == 1; }
		public bool Is([MaybeNullWhen(false)] out T2 value) { value = value2; return index == 2; }
		public bool Is([MaybeNullWhen(false)] out T3 value) { value = value3; return index == 3; }

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

public static partial class OneOfExtensions
{
	public static void Switch<T0, T1, T2, T3>
		(this OneOf<T0, T1, T2, T3>? @this
		,/**/Action<T0> f0
		,/**/Action<T1> f1
		,/**/Action<T2> f2
		,/**/Action<T3> f3
		,/**/Action<object?> fNull
		)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		switch (@this)
		{
		case null: fNull(null); break;
		case OneOf<T0, T1, T2, T3> x:
			x.Switch(f0, f1, f2, f3);
			break;
		}
	}

	public static TResult Match<T0, T1, T2, T3, TResult>
		(this OneOf<T0, T1, T2, T3>? @this
		,/**/Func<T0, TResult> f0
		,/**/Func<T1, TResult> f1
		,/**/Func<T2, TResult> f2
		,/**/Func<T3, TResult> f3
		,/**/Func<object?, TResult> fNull
		)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		return @this switch
		{
			null => fNull(null),
			OneOf<T0, T1, T2, T3> x =>
				x.Match(f0, f1, f2, f3),
		};
	}

	public static bool Is<T0, T1, T2, T3>(this OneOf<T0, T1, T2, T3>? @this, [MaybeNullWhen(false)] out T0 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3>(this OneOf<T0, T1, T2, T3>? @this, [MaybeNullWhen(false)] out T1 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3>(this OneOf<T0, T1, T2, T3>? @this, [MaybeNullWhen(false)] out T2 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1, T2, T3>(this OneOf<T0, T1, T2, T3>? @this, [MaybeNullWhen(false)] out T3 value)
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}
}