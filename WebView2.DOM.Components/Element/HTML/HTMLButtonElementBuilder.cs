using System;

namespace WebView2.DOM.Components;

public abstract class HTMLButtonElementBuilder : HTMLElementBuilder<HTMLButtonElement>
{
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
	/// URL to use for form submission
	/// </summary>
	public AttributeBuilder<Uri> formaction
	{
		get => new(value => element.formAction = value);
		set => element.formAction = value.GetConstantValue();
	}

	/// <summary>
	/// Entry list encoding type to use for form submission
	/// </summary>
	public AttributeBuilder<Enctype> formenctype
	{
		get => new(value => element.formEnctype = value);
		set => element.formEnctype = value.GetConstantValue();
	}

	/// <summary>
	/// Variant to use for form submission
	/// </summary>
	public AttributeBuilder<Method> formmethod
	{
		get => new(value => element.formMethod = value);
		set => element.formMethod = value.GetConstantValue();
	}

	/// <summary>
	/// Bypass form control validation for form submission
	/// </summary>
	public AttributeBuilder<bool> formnovalidate
	{
		get => new(value => element.formNoValidate = value);
		set => element.formNoValidate = value.GetConstantValue();
	}

	/// <summary>
	/// Navigable for form submission
	/// </summary>
	public AttributeBuilder<string> formtarget
	{
		get => new(value => element.formTarget = value);
		set => element.formTarget = value.GetConstantValue();
	}

	/// <summary>
	/// Name of the element to use for form submission and in the form.elements API
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
	}

	///// <summary>
	///// Targets a popover element to toggle, show, or hide
	///// </summary>
	//public AttributeBuilder<TTT> popovertarget
	//{
	//	get => new(value => element.popovertarget = value);
	//	set => element.popovertarget = value.GetConstantValue();
	//}

	///// <summary>
	///// Indicates whether a targeted popover element is to be toggled, shown, or hidden
	///// </summary>
	//public AttributeBuilder<TTT> popovertargetaction
	//{
	//	get => new(value => element.popovertargetaction = value);
	//	set => element.popovertargetaction = value.GetConstantValue();
	//}

	/// <summary>
	/// Type of button
	/// </summary>
	public AttributeBuilder<ButtonType> type
	{
		get => new(value => element.type = value);
		set => element.type = value.GetConstantValue();
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
