using NodaTime;
using OneOf;
using System;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	public sealed class HTMLModElement : HTMLElement
	{
		private HTMLModElement() { }

		public Uri cite { get => Get<Uri>(); set => Set(value); }
		private string _dateTime
		{
			get => Get<string>("dateTime");
			set => Set(value, "dateTime");
		}
		public OneOf<LocalDate, LocalTime, OffsetDateTime>? dateTime
		{
			get => DatesAndTimes.HTMLModElement_dateTime_Parse(_dateTime);
			set => _dateTime = DatesAndTimes.HTMLModElement_dateTime_Format(value);
		}
	}
}
