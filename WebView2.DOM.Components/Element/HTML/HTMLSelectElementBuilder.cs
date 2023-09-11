namespace WebView2.DOM.Components;

public abstract class HTMLSelectElementBuilder : HTMLElementBuilder<HTMLSelectElement>
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
	/// Whether to allow multiple values
	/// </summary>
	public AttributeBuilder<bool> multiple
	{
		get => new(value => element.multiple = value);
		set => element.multiple = value.GetConstantValue();
	}

	/// <summary>
	/// Name of the element to use for form submission and in the form.elements API
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
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
}
