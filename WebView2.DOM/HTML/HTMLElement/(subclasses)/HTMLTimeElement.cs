using Microsoft.Web.WebView2.Core;
using NodaTime;
using OneOf;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	public class HTMLTimeElement : HTMLElement
	{
		protected internal HTMLTimeElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		private string _dateTime
		{
			get => Get<string>("dateTime");
			set => Set(value, "dateTime");
		}

		public OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period>? dateTime
		{
			get => DatesAndTimes.HTMLTimeElement_dateTime_Parse(
					Get<string>("dateTime") is string dateTime && !string.IsNullOrEmpty(dateTime)
					? dateTime
					: innerText
				);

			set
			{
				var formatted = DatesAndTimes.HTMLTimeElement_dateTime_Format(value);

				bool isDateTimeEmpty = string.IsNullOrEmpty(_dateTime);
				bool isInnerTextEmpty = string.IsNullOrEmpty(innerText);

				if (isDateTimeEmpty && !isInnerTextEmpty)
				{
					Set(formatted, property: "innerText");
				}
				else
				{
					Set(formatted, property: "dateTime");
				}
			}
		}
	}
}
