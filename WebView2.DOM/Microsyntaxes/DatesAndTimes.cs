using NodaTime;
using NodaTime.Calendars;
using NodaTime.Text;
using OneOf;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WebView2.DOM.Microsyntaxes
{
	public static class DatesAndTimes
	{
		private static readonly (LocalTimePattern pattern, Func<LocalTime, bool> formatPredicate)[] timePatterns =
			new (LocalTimePattern pattern, Func<LocalTime, bool> formatPredicate)[]
			{
				(LocalTimePattern.CreateWithInvariantCulture("o"), _ => true),
				(LocalTimePattern.CreateWithInvariantCulture("t"), x => x.TickOfDay % NodaConstants.TicksPerMinute == 0),
			};

		private static readonly (OffsetPattern pattern, Func<Offset, bool> formatPredicate)[] timeZoneOffsetPatterns =
			new (OffsetPattern pattern, Func<Offset, bool> formatPredicate)[]
			{
				(OffsetPattern.CreateWithInvariantCulture("Z+HH:mm"), _ => true),
				(OffsetPattern.CreateWithInvariantCulture("Z+HHmm"), _ => false),
			};

		private static readonly YearMonthPattern monthPattern = YearMonthPattern.Iso;

		private static readonly LocalDatePattern datePattern = LocalDatePattern.Iso;

		private static readonly AnnualDatePattern yearlessDatePattern = AnnualDatePattern.Iso;

		private static readonly IPattern<LocalTime> timePattern =
			((Func<IPattern<LocalTime>>)(() =>
			{
				var timePatternBuilder = new CompositePatternBuilder<LocalTime>();

				foreach (var (pattern, formatPredicate) in timePatterns)
				{
					timePatternBuilder.Add(pattern, formatPredicate);
				}

				return timePatternBuilder.Build();
			}))();

		private static readonly IPattern<LocalDateTime> localDateAndTimePattern =
			((Func<IPattern<LocalDateTime>>)(() =>
			{
				var localDateAndTimePatterns =
					from separator in new[] { (PatternText: 'T', Format: true), (PatternText: ' ', Format: false) }
					from time in timePatterns
					select (
						pattern: LocalDateTimePattern.CreateWithInvariantCulture($"ld<{datePattern.PatternText}>{separator.PatternText}lt<{time.pattern.PatternText}>"),
						formatPredicate: (Func<LocalDateTime, bool>)(x => separator.Format && time.formatPredicate(x.TimeOfDay))
					);

				var localDateAndTimePatternBuilder = new CompositePatternBuilder<LocalDateTime>();

				foreach (var (pattern, formatPredicate) in localDateAndTimePatterns)
				{
					localDateAndTimePatternBuilder.Add(pattern, formatPredicate);
				}

				return localDateAndTimePatternBuilder.Build();
			}))();

		private static readonly IPattern<Offset> timeZoneOffsetPattern =
			((Func<IPattern<Offset>>)(() =>
			{
				var timeZoneOffsetPatternBuilder = new CompositePatternBuilder<Offset>();

				foreach (var (pattern, formatPredicate) in timeZoneOffsetPatterns)
				{
					timeZoneOffsetPatternBuilder.Add(pattern, formatPredicate);
				}

				return timeZoneOffsetPatternBuilder.Build();
			}))();

		private static readonly IPattern<OffsetDateTime> globalDateAndTimePattern =
			((Func<IPattern<OffsetDateTime>>)(() =>
			{
				var globalDateAndTimePatterns =
					from separator in new[] { (PatternText: 'T', Format: true), (PatternText: ' ', Format: false) }
					from time in timePatterns
					from timeZoneOffset in timeZoneOffsetPatterns
					select (
						pattern: OffsetDateTimePattern.CreateWithInvariantCulture($"ld<{datePattern.PatternText}>{separator.PatternText}lt<{time.pattern.PatternText}>o<{timeZoneOffset.pattern.PatternText}>"),
						formatPredicate: (Func<OffsetDateTime, bool>)(x => separator.Format && time.formatPredicate(x.TimeOfDay) && timeZoneOffset.formatPredicate(x.Offset))
					);

				var globalDateAndTimePatternBuilder = new CompositePatternBuilder<OffsetDateTime>();

				foreach (var (pattern, formatPredicate) in globalDateAndTimePatterns)
				{
					globalDateAndTimePatternBuilder.Add(pattern, formatPredicate);
				}

				return globalDateAndTimePatternBuilder.Build();
			}))();

		private static readonly IsoWeekPattern weekPattern = new IsoWeekPattern();

		private static readonly YearPattern yearPattern = new YearPattern();

		private static readonly IPattern<Period> durationPattern =
			new CompositePatternBuilder<Period>
			{
				{ PeriodPattern.NormalizingIso, _ => true },
				{ new HumanReadablePeriodPattern(), _ => false },
			}
			.Build();

		private static readonly NullPattern nullPattern = new NullPattern();

		static DatesAndTimes()
		{
			PatternDict<YearMonth>.value = monthPattern;
			PatternDict<LocalDate>.value = datePattern;
			PatternDict<AnnualDate>.value = yearlessDatePattern;
			PatternDict<LocalTime>.value = timePattern;
			PatternDict<LocalDateTime>.value = localDateAndTimePattern;
			PatternDict<Offset>.value = timeZoneOffsetPattern;
			PatternDict<OffsetDateTime>.value = globalDateAndTimePattern;
			PatternDict<IsoWeek>.value = weekPattern;
			PatternDict<Year>.value = yearPattern;
			PatternDict<Period>.value = durationPattern;
			PatternDict<Null>.value = nullPattern;
		}

		public static OneOf<LocalDate, LocalTime, OffsetDateTime, Null> HTMLModElement_dateTime_Parse(string text) =>
			OneOfPattern<LocalDate, LocalTime, OffsetDateTime, Null>.Instance.Parse(text).Value;

		public static string HTMLModElement_dateTime_Format(OneOf<LocalDate, LocalTime, OffsetDateTime, Null> value) =>
			OneOfPattern<LocalDate, LocalTime, OffsetDateTime, Null>.Instance.Format(value);

		public static OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period, Null> HTMLTimeElement_dateTime_Parse(string text) =>
			OneOfPattern<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period, Null>.Instance.Parse(text).Value;

		public static string HTMLTimeElement_dateTime_Format(OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period, Null> value) =>
			OneOfPattern<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period, Null>.Instance.Format(value);
	}

	public struct Year
	{
		public int Value { get; }

		public Year(int value) => Value = value;
	}

	internal struct YearPattern : IPattern<Year>
	{
		private static IPattern<LocalDate> innerPattern = LocalDatePattern.CreateWithInvariantCulture("uuuu");

		public StringBuilder AppendFormat(Year value, StringBuilder builder) =>
			innerPattern.AppendFormat(new LocalDate(value.Value, 1, 1), builder);

		public string Format(Year value) =>
			innerPattern.Format(new LocalDate(value.Value, 1, 1));

		public ParseResult<Year> Parse(string text) =>
			innerPattern.Parse(text).Convert(result => new Year(result.Year));
	}

	public struct IsoWeek
	{
		public int WeekYear { get; }
		public int Week { get; }

		public IsoWeek(int weekYear, int week)
		{
			WeekYearRules.Iso.GetLocalDate(weekYear, week, IsoDayOfWeek.Monday);
			(WeekYear, Week) = (weekYear, week);
		}

		public LocalDate OnDayOfWeek(IsoDayOfWeek dayOfWeek)
		{
			return WeekYearRules.Iso.GetLocalDate(WeekYear, Week, dayOfWeek);
		}
	}

	internal struct IsoWeekPattern : IPattern<IsoWeek>
	{
		private static IPattern<LocalDateTime> innerPattern = LocalDateTimePattern.CreateWithInvariantCulture("uuuu'-W'mm");

		public StringBuilder AppendFormat(IsoWeek value, StringBuilder builder) =>
			innerPattern.AppendFormat(new LocalDateTime(value.WeekYear, 1, 1, 1, value.Week), builder);

		public string Format(IsoWeek value) =>
			innerPattern.Format(new LocalDateTime(value.WeekYear, 1, 1, 1, value.Week));

		public ParseResult<IsoWeek> Parse(string text) =>
			innerPattern.Parse(text).Convert(result => new IsoWeek(result.Year, result.Minute));
	}

	internal struct HumanReadablePeriodPattern : IPattern<Period>
	{
		private static IPattern<Period> innerPattern = PeriodPattern.NormalizingIso;

		public StringBuilder AppendFormat(Period value, StringBuilder builder)
		{
			throw new NotImplementedException();
		}

		public string Format(Period value)
		{
			throw new NotImplementedException();
		}

		public ParseResult<Period> Parse(string text)
		{
			try
			{
				var array = text.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);

				var first = array.First();

				var dict = array.ToDictionary(
					x => char.ToLowerInvariant(x[^1]),
					x => int.Parse(x[0..^1], NumberStyles.None, CultureInfo.InvariantCulture));

				var builder = new PeriodBuilder
				{
					Weeks = dict.GetValueOrDefault('w'),
					Days = dict.GetValueOrDefault('d'),
					Hours = dict.GetValueOrDefault('h'),
					Minutes = dict.GetValueOrDefault('m'),
					Seconds = dict.GetValueOrDefault('s'),
				};
				return ParseResult<Period>.ForValue(builder.Build().Normalize());
			}
			catch (Exception ex)
			{
				return ParseResult<Period>.ForException(() => ex);
			}
		}
	}

	internal struct NullPattern : IPattern<Null>
	{
		public StringBuilder AppendFormat(Null value, StringBuilder builder) => builder;

		public string Format(Null value) => "";

		public ParseResult<Null> Parse(string text) => ParseResult<Null>.ForValue(default);
	}
}
