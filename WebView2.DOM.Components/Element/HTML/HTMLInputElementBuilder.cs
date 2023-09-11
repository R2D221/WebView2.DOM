using NodaTime.Text;
using System.Text.Json;

namespace WebView2.DOM.Components;

public abstract class HTMLInputElementBuilder<THTMLInputElement> : HTMLElementBuilder<THTMLInputElement>
	where THTMLInputElement : HTMLInputElement
{
	internal sealed override bool CanAddChild(Node child) => false;

	/// <summary>
	/// Whether the form control is disabled
	/// </summary>
	public AttributeBuilder<bool> disabled
	{
		get => new(value => element.disabled = value);
		set => element.disabled = value.GetConstantValue();
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
	/// Name of the element to use for form submission and in the form.elements API
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
	}
}

public abstract class HTMLInputElementWithTextBuilder<THTMLInputElementWithText> : HTMLInputElementBuilder<THTMLInputElementWithText>
	where THTMLInputElementWithText : HTMLInputElement.WithText
{
	/// <summary>
	/// Hint for form autofill feature
	/// </summary>
	public AttributeBuilder<string> autocomplete
	{
		get => new(value => element.autocomplete = value);
		set => element.autocomplete = value.GetConstantValue();
	}

	/// <summary>
	/// Minimum length of value
	/// </summary>
	public AttributeBuilder<int> minlength
	{
		get => new(value => element.minLength = value);
		set => element.minLength = value.GetConstantValue();
	}

	/// <summary>
	/// Maximum length of value
	/// </summary>
	public AttributeBuilder<int> maxlength
	{
		get => new(value => element.maxLength = value);
		set => element.maxLength = value.GetConstantValue();
	}

	/// <summary>
	/// Pattern to be matched by the form control's value
	/// </summary>
	public AttributeBuilder<string> pattern
	{
		get => new(value => element.pattern = value);
		set => element.pattern = value.GetConstantValue();
	}

	/// <summary>
	/// User-visible label to be placed within the form control
	/// </summary>
	public AttributeBuilder<string> placeholder
	{
		get => new(value => element.placeholder = value);
		set => element.placeholder = value.GetConstantValue();
	}

	/// <summary>
	/// Whether to allow the value to be edited by the user
	/// </summary>
	public AttributeBuilder<bool> @readonly
	{
		get => new(value => element.readOnly = value);
		set => element.readOnly = value.GetConstantValue();
	}

	/// <summary>
	/// Whether the control is required for form submission
	/// </summary>
	public AttributeBuilder<bool> required
	{
		get => new(value => element.required = value);
		set => element.required = value.GetConstantValue();
	}

	/// <summary>
	/// Size of the control
	/// </summary>
	public AttributeBuilder<uint> size
	{
		get => new(value => element.size = value);
		set => element.size = value.GetConstantValue();
	}

	/// <summary>
	/// Value of the form control
	/// </summary>
	public TwoWayAttributeBuilder<string> value
	{
		get => new(() => element.value, x => element.onchange += x);
		set => element.value = value.GetConstantValue();
	}
}

public abstract class HTMLInputElementWithValueBuilder<THTMLInputElementWithValue, TValue> : HTMLInputElementBuilder<THTMLInputElementWithValue>
	where THTMLInputElementWithValue : HTMLInputElement.WithValue<TValue>
	where TValue : struct
{
	/// <summary>
	/// Hint for form autofill feature
	/// </summary>
	public AttributeBuilder<string> autocomplete
	{
		get => new(value => element.autocomplete = value);
		set => element.autocomplete = value.GetConstantValue();
	}

	/// <summary>
	/// List of autocomplete options
	/// </summary>
	public AttributeBuilder<string?> list
	{
		get => new(value => SetOrRemoveAttribute(nameof(list), value));
		set => SetOrRemoveAttribute(nameof(list), value.GetConstantValue());
	}

	/// <summary>
	/// Value of the form control
	/// </summary>
	public TwoWayAttributeBuilder<TValue?> value
	{
		get => new(() => element.value, x => element.onchange += x);
		set => element.value = value.GetConstantValue();
	}

	/// <summary>
	/// Minimum value
	/// </summary>
	public AttributeBuilder<TValue?> min
	{
		get => new(value => element.min = value);
		set => element.min = value.GetConstantValue();
	}

	/// <summary>
	/// Maximum value
	/// </summary>
	public AttributeBuilder<TValue?> max
	{
		get => new(value => element.max = value);
		set => element.max = value.GetConstantValue();
	}

	/// <summary>
	/// Granularity to be matched by the form control's value
	/// </summary>
	public AttributeBuilder<double> step
	{
		get => new(value => element.step = value);
		set => element.step = value.GetConstantValue();
	}
}

public abstract class HTMLInputElementWithCheckednessBuilder<THTMLInputElementWithCheckedness> : HTMLInputElementBuilder<THTMLInputElementWithCheckedness>
	where THTMLInputElementWithCheckedness : HTMLInputElement.WithCheckedness
{
	/// <summary>
	/// Whether the control is required for form submission
	/// </summary>
	public AttributeBuilder<bool> required
	{
		get => new(value => element.required = value);
		set => element.required = value.GetConstantValue();
	}

	/// <summary>
	/// Value of the form control
	/// </summary>
	public AttributeBuilder<string> value
	{
		get => new(value => element.value = value);
		set => element.value = value.GetConstantValue();
	}

	/// <summary>
	/// Whether the control is checked
	/// </summary>
	public TwoWayAttributeBuilder<bool> @checked
	{
		get => new(() => element.@checked, x => element.onchange += x);
		set => element.@checked = value.GetConstantValue();
	}
}
