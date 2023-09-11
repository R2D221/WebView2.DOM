using NodaTime;
using OneOf;
using System;

namespace WebView2.DOM.Components;

public abstract class HTMLModElementBuilder : HTMLElementBuilder<HTMLModElement>
{
	/// <summary>
	/// More information about the edit
	/// </summary>
	public AttributeBuilder<Uri> cite
	{
		get => new(value => element.cite = value);
		set => element.cite = value.GetConstantValue();
	}

	/// <summary>
	/// Date and (optionally) time of the change
	/// </summary>
	public AttributeBuilder<OneOf<LocalDate, LocalTime, OffsetDateTime>?> datetime
	{
		get => new(value => element.dateTime = value);
		set => element.dateTime = value.GetConstantValue();
	}
}
