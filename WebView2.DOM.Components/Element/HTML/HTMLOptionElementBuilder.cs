using System;
using System.Runtime.CompilerServices;

namespace WebView2.DOM.Components;

public abstract class HTMLOptionElementBuilder : HTMLElementBuilder<HTMLOptionElement>
{
	internal static ConditionalWeakTable<HTMLOptionElement, ExtraEvents> extraEvents = new();

	internal class ExtraEvents
	{
		public EventHandler<Event>? selectedChanged { get; set; }
	}

	/// <summary>
	/// Whether the form control is disabled
	/// </summary>
	public AttributeBuilder<bool> disabled
	{
		get => new(value => element.disabled = value);
		set => element.disabled = value.GetConstantValue();
	}

	/// <summary>
	/// User-visible label
	/// </summary>
	public AttributeBuilder<string> label
	{
		get => new(value => element.label = value);
		set => element.label = value.GetConstantValue();
	}

	/// <summary>
	/// Whether the option is selected
	/// </summary>
	public TwoWayAttributeBuilder<bool> selected
	{
		get => new(() => element.selected, x => extraEvents.GetValue(element, _ => new()).selectedChanged += x);
		set => element.selected = value.GetConstantValue();
	}

	/// <summary>
	/// Value to be used for form submission
	/// </summary>
	public AttributeBuilder<string> value
	{
		get => new(value => element.value = value);
		set => element.value = value.GetConstantValue();
	}
}
