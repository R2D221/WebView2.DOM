using OneOf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace OneOf
{
	[DebuggerDisplay("{Value}")]
	public struct OneOf<T0, T1> : IEquatable<OneOf<T0, T1>>
		where T0 : notnull
		where T1 : notnull
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

		OneOf(T0 value) : this(false) => (index, value0) = (0, value ?? throw new ArgumentNullException(nameof(value)));
		OneOf(T1 value) : this(false) => (index, value1) = (1, value ?? throw new ArgumentNullException(nameof(value)));

		public static implicit operator OneOf<T0, T1>(T0 t) => new OneOf<T0, T1>(t);
		public static implicit operator OneOf<T0, T1>(T1 t) => new OneOf<T0, T1>(t);

		public object? Value => index switch
		{
			0 => value0,
			1 => value1,
			_ => throw new InvalidOperationException(),
		};

		public bool Is([MaybeNullWhen(false)] out T0 value) { value = value0; return index == 0; }
		public bool Is([MaybeNullWhen(false)] out T1 value) { value = value1; return index == 1; }

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

public static partial class OneOfExtensions
{
	public static void Switch<T0, T1>
		(this OneOf<T0, T1>? @this
		,/**/Action<T0> f0
		,/**/Action<T1> f1
		,/**/Action<object?> fNull
		)
		where T0 : notnull
		where T1 : notnull
	{
		switch (@this)
		{
		case null: fNull(null); break;
		case OneOf<T0, T1> x: x.Switch(f0, f1); break;
		}
	}

	public static TResult Match<T0, T1, TResult>
		(this OneOf<T0, T1>? @this
		,/**/Func<T0, TResult> f0
		,/**/Func<T1, TResult> f1
		,/**/Func<object?, TResult> fNull
		)
		where T0 : notnull
		where T1 : notnull
	{
		return @this switch
		{
			null => fNull(null),
			OneOf<T0, T1> x => x.Match(f0, f1),
		};
	}

	public static bool Is<T0, T1>(this OneOf<T0, T1>? @this, [MaybeNullWhen(false)] out T0 value)
		where T0 : notnull
		where T1 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}

	public static bool Is<T0, T1>(this OneOf<T0, T1>? @this, [MaybeNullWhen(false)] out T1 value)
		where T0 : notnull
		where T1 : notnull
	{
		if (@this is null) { value = default!; return false; }
		return @this.Value.Is(out value);
	}
}