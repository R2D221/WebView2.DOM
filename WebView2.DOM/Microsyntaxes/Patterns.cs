using NodaTime.Text;
using OneOf;
using System;
using System.Text;

namespace WebView2.DOM
{
	internal class Pattern<T> : IPattern<T>
	{
		public Func<T, StringBuilder, StringBuilder> AppendFormat { get; set; } =
			(_, __) => throw new NotImplementedException();

		StringBuilder IPattern<T>.AppendFormat(T value, StringBuilder builder) =>
			AppendFormat(value, builder);

		public Func<T, string> Format { get; set; } =
			(_) => throw new NotImplementedException();

		string IPattern<T>.Format(T value) =>
			Format(value);

		public Func<string, ParseResult<T>> Parse { get; set; } =
			(_) => throw new NotImplementedException();

		ParseResult<T> IPattern<T>.Parse(string text) =>
			Parse(text);
	}

	internal static class PatternDict<T>
	{
		public static IPattern<T> value = default!;
	}

	internal static class OneOfPattern<T0, T1>
		where T0 : notnull
		where T1 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1>> Instance =
			new Pattern<OneOf<T0, T1>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1>)x) :
					ParseResult<OneOf<T0, T1>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2>> Instance =
			new Pattern<OneOf<T0, T1, T2>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2>)x) :
					ParseResult<OneOf<T0, T1, T2>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3>)x) :
					ParseResult<OneOf<T0, T1, T2, T3>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3, T4>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder),
						t4 => PatternDict<T4>.value.AppendFormat(t4, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3),
						t4 => PatternDict<T4>.value.Format(t4)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3, T4>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3, T4>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3, T4>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3, T4>)x) :
					PatternDict<T4>.value.Parse(text) is var t4 && t4.Success ? t4.Convert(x => (OneOf<T0, T1, T2, T3, T4>)x) :
					ParseResult<OneOf<T0, T1, T2, T3, T4>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3, T4, T5>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder),
						t4 => PatternDict<T4>.value.AppendFormat(t4, builder),
						t5 => PatternDict<T5>.value.AppendFormat(t5, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3),
						t4 => PatternDict<T4>.value.Format(t4),
						t5 => PatternDict<T5>.value.Format(t5)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x) :
					PatternDict<T4>.value.Parse(text) is var t4 && t4.Success ? t4.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x) :
					PatternDict<T5>.value.Parse(text) is var t5 && t5.Success ? t5.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x) :
					ParseResult<OneOf<T0, T1, T2, T3, T4, T5>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder),
						t4 => PatternDict<T4>.value.AppendFormat(t4, builder),
						t5 => PatternDict<T5>.value.AppendFormat(t5, builder),
						t6 => PatternDict<T6>.value.AppendFormat(t6, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3),
						t4 => PatternDict<T4>.value.Format(t4),
						t5 => PatternDict<T5>.value.Format(t5),
						t6 => PatternDict<T6>.value.Format(t6)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x) :
					PatternDict<T4>.value.Parse(text) is var t4 && t4.Success ? t4.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x) :
					PatternDict<T5>.value.Parse(text) is var t5 && t5.Success ? t5.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x) :
					PatternDict<T6>.value.Parse(text) is var t6 && t6.Success ? t6.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x) :
					ParseResult<OneOf<T0, T1, T2, T3, T4, T5, T6>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder),
						t4 => PatternDict<T4>.value.AppendFormat(t4, builder),
						t5 => PatternDict<T5>.value.AppendFormat(t5, builder),
						t6 => PatternDict<T6>.value.AppendFormat(t6, builder),
						t7 => PatternDict<T7>.value.AppendFormat(t7, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3),
						t4 => PatternDict<T4>.value.Format(t4),
						t5 => PatternDict<T5>.value.Format(t5),
						t6 => PatternDict<T6>.value.Format(t6),
						t7 => PatternDict<T7>.value.Format(t7)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					PatternDict<T4>.value.Parse(text) is var t4 && t4.Success ? t4.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					PatternDict<T5>.value.Parse(text) is var t5 && t5.Success ? t5.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					PatternDict<T6>.value.Parse(text) is var t6 && t6.Success ? t6.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					PatternDict<T7>.value.Parse(text) is var t7 && t7.Success ? t7.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x) :
					ParseResult<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7, T8>
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
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder),
						t4 => PatternDict<T4>.value.AppendFormat(t4, builder),
						t5 => PatternDict<T5>.value.AppendFormat(t5, builder),
						t6 => PatternDict<T6>.value.AppendFormat(t6, builder),
						t7 => PatternDict<T7>.value.AppendFormat(t7, builder),
						t8 => PatternDict<T8>.value.AppendFormat(t8, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3),
						t4 => PatternDict<T4>.value.Format(t4),
						t5 => PatternDict<T5>.value.Format(t5),
						t6 => PatternDict<T6>.value.Format(t6),
						t7 => PatternDict<T7>.value.Format(t7),
						t8 => PatternDict<T8>.value.Format(t8)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T4>.value.Parse(text) is var t4 && t4.Success ? t4.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T5>.value.Parse(text) is var t5 && t5.Success ? t5.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T6>.value.Parse(text) is var t6 && t6.Success ? t6.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T7>.value.Parse(text) is var t7 && t7.Success ? t7.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					PatternDict<T8>.value.Parse(text) is var t8 && t8.Success ? t8.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x) :
					ParseResult<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder),
						t4 => PatternDict<T4>.value.AppendFormat(t4, builder),
						t5 => PatternDict<T5>.value.AppendFormat(t5, builder),
						t6 => PatternDict<T6>.value.AppendFormat(t6, builder),
						t7 => PatternDict<T7>.value.AppendFormat(t7, builder),
						t8 => PatternDict<T8>.value.AppendFormat(t8, builder),
						t9 => PatternDict<T9>.value.AppendFormat(t9, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3),
						t4 => PatternDict<T4>.value.Format(t4),
						t5 => PatternDict<T5>.value.Format(t5),
						t6 => PatternDict<T6>.value.Format(t6),
						t7 => PatternDict<T7>.value.Format(t7),
						t8 => PatternDict<T8>.value.Format(t8),
						t9 => PatternDict<T9>.value.Format(t9)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T4>.value.Parse(text) is var t4 && t4.Success ? t4.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T5>.value.Parse(text) is var t5 && t5.Success ? t5.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T6>.value.Parse(text) is var t6 && t6.Success ? t6.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T7>.value.Parse(text) is var t7 && t7.Success ? t7.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T8>.value.Parse(text) is var t8 && t8.Success ? t8.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					PatternDict<T9>.value.Parse(text) is var t9 && t9.Success ? t9.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x) :
					ParseResult<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>.ForException(() => new UnparsableValueException())
			};
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
		where T10 : notnull
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> Instance =
			new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
			{
				AppendFormat = (value, builder) =>
					value.Match(
						t0 => PatternDict<T0>.value.AppendFormat(t0, builder),
						t1 => PatternDict<T1>.value.AppendFormat(t1, builder),
						t2 => PatternDict<T2>.value.AppendFormat(t2, builder),
						t3 => PatternDict<T3>.value.AppendFormat(t3, builder),
						t4 => PatternDict<T4>.value.AppendFormat(t4, builder),
						t5 => PatternDict<T5>.value.AppendFormat(t5, builder),
						t6 => PatternDict<T6>.value.AppendFormat(t6, builder),
						t7 => PatternDict<T7>.value.AppendFormat(t7, builder),
						t8 => PatternDict<T8>.value.AppendFormat(t8, builder),
						t9 => PatternDict<T9>.value.AppendFormat(t9, builder),
						t10 => PatternDict<T10>.value.AppendFormat(t10, builder)
					),
				Format = (value) =>
					value.Match(
						t0 => PatternDict<T0>.value.Format(t0),
						t1 => PatternDict<T1>.value.Format(t1),
						t2 => PatternDict<T2>.value.Format(t2),
						t3 => PatternDict<T3>.value.Format(t3),
						t4 => PatternDict<T4>.value.Format(t4),
						t5 => PatternDict<T5>.value.Format(t5),
						t6 => PatternDict<T6>.value.Format(t6),
						t7 => PatternDict<T7>.value.Format(t7),
						t8 => PatternDict<T8>.value.Format(t8),
						t9 => PatternDict<T9>.value.Format(t9),
						t10 => PatternDict<T10>.value.Format(t10)
					),
				Parse = (text) =>
					PatternDict<T0>.value.Parse(text) is var t0 && t0.Success ? t0.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T1>.value.Parse(text) is var t1 && t1.Success ? t1.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T2>.value.Parse(text) is var t2 && t2.Success ? t2.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T3>.value.Parse(text) is var t3 && t3.Success ? t3.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T4>.value.Parse(text) is var t4 && t4.Success ? t4.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T5>.value.Parse(text) is var t5 && t5.Success ? t5.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T6>.value.Parse(text) is var t6 && t6.Success ? t6.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T7>.value.Parse(text) is var t7 && t7.Success ? t7.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T8>.value.Parse(text) is var t8 && t8.Success ? t8.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T9>.value.Parse(text) is var t9 && t9.Success ? t9.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					PatternDict<T10>.value.Parse(text) is var t10 && t10.Success ? t10.Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x) :
					ParseResult<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>.ForException(() => new UnparsableValueException())
			};
	}
}
