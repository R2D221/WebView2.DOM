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
	{
		public static readonly IPattern<OneOf<T0, T1>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1>>
			{
				{
					new Pattern<OneOf<T0, T1>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1>)x),
					},
					value => value.Is<T1>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2>
	{
		public static readonly IPattern<OneOf<T0, T1, T2>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2>>
			{
				{
					new Pattern<OneOf<T0, T1, T2>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2>)x),
					},
					value => value.Is<T2>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3>)x),
					},
					value => value.Is<T3>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3, T4>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4>)x),
					},
					value => value.Is<T3>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T4>.value.AppendFormat/*	*/(value.As<T4>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T4>.value.Format/*	*/(value.As<T4>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T4>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4>)x),
					},
					value => value.Is<T4>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3, T4, T5>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x),
					},
					value => value.Is<T3>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T4>.value.AppendFormat/*	*/(value.As<T4>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T4>.value.Format/*	*/(value.As<T4>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T4>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x),
					},
					value => value.Is<T4>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T5>.value.AppendFormat/*	*/(value.As<T5>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T5>.value.Format/*	*/(value.As<T5>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T5>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5>)x),
					},
					value => value.Is<T5>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3, T4, T5, T6>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x),
					},
					value => value.Is<T3>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T4>.value.AppendFormat/*	*/(value.As<T4>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T4>.value.Format/*	*/(value.As<T4>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T4>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x),
					},
					value => value.Is<T4>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T5>.value.AppendFormat/*	*/(value.As<T5>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T5>.value.Format/*	*/(value.As<T5>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T5>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x),
					},
					value => value.Is<T5>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T6>.value.AppendFormat/*	*/(value.As<T6>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T6>.value.Format/*	*/(value.As<T6>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T6>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6>)x),
					},
					value => value.Is<T6>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T3>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T4>.value.AppendFormat/*	*/(value.As<T4>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T4>.value.Format/*	*/(value.As<T4>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T4>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T4>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T5>.value.AppendFormat/*	*/(value.As<T5>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T5>.value.Format/*	*/(value.As<T5>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T5>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T5>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T6>.value.AppendFormat/*	*/(value.As<T6>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T6>.value.Format/*	*/(value.As<T6>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T6>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T6>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T7>.value.AppendFormat/*	*/(value.As<T7>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T7>.value.Format/*	*/(value.As<T7>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T7>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7>)x),
					},
					value => value.Is<T7>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7, T8>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T3>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T4>.value.AppendFormat/*	*/(value.As<T4>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T4>.value.Format/*	*/(value.As<T4>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T4>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T4>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T5>.value.AppendFormat/*	*/(value.As<T5>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T5>.value.Format/*	*/(value.As<T5>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T5>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T5>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T6>.value.AppendFormat/*	*/(value.As<T6>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T6>.value.Format/*	*/(value.As<T6>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T6>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T6>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T7>.value.AppendFormat/*	*/(value.As<T7>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T7>.value.Format/*	*/(value.As<T7>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T7>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T7>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T8>.value.AppendFormat/*	*/(value.As<T8>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T8>.value.Format/*	*/(value.As<T8>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T8>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>)x),
					},
					value => value.Is<T8>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T3>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T4>.value.AppendFormat/*	*/(value.As<T4>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T4>.value.Format/*	*/(value.As<T4>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T4>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T4>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T5>.value.AppendFormat/*	*/(value.As<T5>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T5>.value.Format/*	*/(value.As<T5>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T5>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T5>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T6>.value.AppendFormat/*	*/(value.As<T6>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T6>.value.Format/*	*/(value.As<T6>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T6>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T6>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T7>.value.AppendFormat/*	*/(value.As<T7>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T7>.value.Format/*	*/(value.As<T7>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T7>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T7>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T8>.value.AppendFormat/*	*/(value.As<T8>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T8>.value.Format/*	*/(value.As<T8>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T8>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T8>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T9>.value.AppendFormat/*	*/(value.As<T9>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T9>.value.Format/*	*/(value.As<T9>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T9>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)x),
					},
					value => value.Is<T9>()
				},
			}
			.Build();
	}

	internal static class OneOfPattern<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
	{
		public static readonly IPattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> Instance =
			new CompositePatternBuilder<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
			{
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T0>.value.AppendFormat/*	*/(value.As<T0>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T0>.value.Format/*	*/(value.As<T0>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T0>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T0>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T1>.value.AppendFormat/*	*/(value.As<T1>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T1>.value.Format/*	*/(value.As<T1>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T1>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T1>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T2>.value.AppendFormat/*	*/(value.As<T2>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T2>.value.Format/*	*/(value.As<T2>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T2>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T2>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T3>.value.AppendFormat/*	*/(value.As<T3>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T3>.value.Format/*	*/(value.As<T3>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T3>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T3>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T4>.value.AppendFormat/*	*/(value.As<T4>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T4>.value.Format/*	*/(value.As<T4>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T4>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T4>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T5>.value.AppendFormat/*	*/(value.As<T5>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T5>.value.Format/*	*/(value.As<T5>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T5>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T5>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T6>.value.AppendFormat/*	*/(value.As<T6>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T6>.value.Format/*	*/(value.As<T6>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T6>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T6>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T7>.value.AppendFormat/*	*/(value.As<T7>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T7>.value.Format/*	*/(value.As<T7>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T7>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T7>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T8>.value.AppendFormat/*	*/(value.As<T8>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T8>.value.Format/*	*/(value.As<T8>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T8>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T8>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T9>.value.AppendFormat/*	*/(value.As<T9>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T9>.value.Format/*	*/(value.As<T9>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T9>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T9>()
				},
				{
					new Pattern<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
					{
						AppendFormat/*	*/= (value, builder)/*	*/=> PatternDict<T10>.value.AppendFormat/*	*/(value.As<T10>(), builder),
						Format/*	*/= (value)/*	*/=> PatternDict<T10>.value.Format/*	*/(value.As<T10>()),
						Parse/*	*/= (text)/*	*/=> PatternDict<T10>.value.Parse(text).Convert(x => (OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)x),
					},
					value => value.Is<T10>()
				},
			}
			.Build();
	}
}
