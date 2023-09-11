using NodaTime;
using OneOf;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM.Components;

public abstract class HTMLTimeElementBuilder : HTMLElementBuilder<HTMLTimeElement>
{
	/// <summary>
	/// Machine-readable value
	/// </summary>
	public AttributeBuilder<OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period>?> datetime
	{
		get => new(value => element.dateTime = value);
		set => element.dateTime = value.GetConstantValue();
	}
}
