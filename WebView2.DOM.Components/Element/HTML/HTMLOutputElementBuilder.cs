using System.Collections.Generic;

namespace WebView2.DOM.Components;

public abstract class HTMLOutputElementBuilder : HTMLElementBuilder<HTMLOutputElement>
{
	/// <summary>
	/// Specifies controls from which the output was calculated
	/// </summary>
	public AttributeBuilder<IReadOnlyList<string>> @for
	{
		get => new(value => element.htmlFor.value = string.Join(" ", value));
		set => element.htmlFor.value = string.Join(" ", value.GetConstantValue());
	}

	/// <summary>
	/// Associates the element with a form element
	/// </summary>
	public AttributeBuilder<string?> form
	{
		get => new(value => SetOrRemoveAttribute(nameof(form), value));
		set => SetOrRemoveAttribute(nameof(form), value.GetConstantValue());
	}

	/// <summary>
	/// Name of the element to use in the form.elements API
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
	}
}
