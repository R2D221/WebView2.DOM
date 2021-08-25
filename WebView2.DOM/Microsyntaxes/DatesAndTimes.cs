﻿using NodaTime;
using NodaTime.Calendars;
using NodaTime.Text;
using OneOf;
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

		internal static readonly YearMonthPattern monthPattern = YearMonthPattern.Iso;

		internal static readonly LocalDatePattern datePattern = LocalDatePattern.Iso;

		internal static readonly AnnualDatePattern yearlessDatePattern = AnnualDatePattern.Iso;

		internal static readonly IPattern<LocalTime> timePattern =
			((Func<IPattern<LocalTime>>)(() =>
			{
				var timePatternBuilder = new CompositePatternBuilder<LocalTime>();

				foreach (var (pattern, formatPredicate) in timePatterns)
				{
					timePatternBuilder.Add(pattern, formatPredicate);
				}

				return timePatternBuilder.Build();
			}))();

		internal static readonly IPattern<LocalDateTime> localDateAndTimePattern =
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

		internal static readonly IPattern<Offset> timeZoneOffsetPattern =
			((Func<IPattern<Offset>>)(() =>
			{
				var timeZoneOffsetPatternBuilder = new CompositePatternBuilder<Offset>();

				foreach (var (pattern, formatPredicate) in timeZoneOffsetPatterns)
				{
					timeZoneOffsetPatternBuilder.Add(pattern, formatPredicate);
				}

				return timeZoneOffsetPatternBuilder.Build();
			}))();

		internal static readonly IPattern<OffsetDateTime> globalDateAndTimePattern =
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

		internal static readonly IsoWeekPattern weekPattern = new IsoWeekPattern();

		internal static readonly YearPattern yearPattern = new YearPattern();

		internal static readonly IPattern<Period> durationPattern =
			new CompositePatternBuilder<Period>
			{
				{ PeriodPattern.NormalizingIso, _ => true },
				{ new HumanReadablePeriodPattern(), _ => false },
			}
			.Build();

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
		}

		public static OneOf<LocalDate, LocalTime, OffsetDateTime>? HTMLModElement_dateTime_Parse(string text) =>
			OneOfPattern<LocalDate, LocalTime, OffsetDateTime>.Instance.Parse(text).TryGetValue(default, out var result)
			? result
			: default(OneOf<LocalDate, LocalTime, OffsetDateTime>?);

		public static string HTMLModElement_dateTime_Format(OneOf<LocalDate, LocalTime, OffsetDateTime>? value) =>
			value switch
			{
				null => "",
				{ } x => OneOfPattern<LocalDate, LocalTime, OffsetDateTime>.Instance.Format(x),
			};

		public static OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period>? HTMLTimeElement_dateTime_Parse(string text) =>
			OneOfPattern<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period>.Instance.Parse(text).TryGetValue(default, out var result)
			? result
			: default(OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period>?);

		public static string HTMLTimeElement_dateTime_Format(OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period>? value) =>
			value switch
			{
				null => "",
				{ } x => OneOfPattern<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period>.Instance.Format(x),
			};
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
			// We call IWeekYearRule.GetLocalDate to leverage
			// NodaTime's validations to assert that weekYear
			// and week do indeed refer to a valid ISO week year.
			_ = WeekYearRules.Iso.GetLocalDate(weekYear, week, IsoDayOfWeek.Monday);

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

		public StringBuilder AppendFormat(Period value, StringBuilder builder) =>
			innerPattern.AppendFormat(value, builder);

		public string Format(Period value) =>
			innerPattern.Format(value);

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
}
