namespace WebView2.DOM.Components;

public abstract class HTMLTextAreaElementBuilder : HTMLElementBuilder<HTMLTextAreaElement>
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
	/// Maximum number of characters per line
	/// </summary>
	public AttributeBuilder<uint> cols
	{
		get => new(value => element.cols = value);
		set => element.cols = value.GetConstantValue();
	}

	/// <summary>
	/// Name of form control to use for sending the element's directionality in form submission
	/// </summary>
	public AttributeBuilder<string> dirname
	{
		get => new(value => element.dirName = value);
		set => element.dirName = value.GetConstantValue();
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
	/// Maximum length of value
	/// </summary>
	public AttributeBuilder<int> maxlength
	{
		get => new(value => element.maxLength = value);
		set => element.maxLength = value.GetConstantValue();
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
	/// Name of the element to use for form submission and in the form.elements API
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
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
	/// Number of lines to show
	/// </summary>
	public AttributeBuilder<uint> rows
	{
		get => new(value => element.rows = value);
		set => element.rows = value.GetConstantValue();
	}

	/// <summary>
	/// How the value of the form control is to be wrapped for form submission
	/// </summary>
	public AttributeBuilder<Wrap> wrap
	{
		get => new(value => element.wrap = value);
		set => element.wrap = value.GetConstantValue();
	}
}
