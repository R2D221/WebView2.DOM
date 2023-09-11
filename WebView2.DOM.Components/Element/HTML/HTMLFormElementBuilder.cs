using System;

namespace WebView2.DOM.Components;
public abstract class HTMLFormElementBuilder : HTMLElementBuilder<HTMLFormElement>
{
	/// <summary>
	/// Character encodings to use for form submission
	/// </summary>
	public AttributeBuilder<string> accept_charset
	{
		get => new(value => element.acceptCharset = value);
		set => element.acceptCharset = value.GetConstantValue();
	}

	/// <summary>
	/// URL to use for form submission
	/// </summary>
	public AttributeBuilder<Uri> action
	{
		get => new(value => element.action = value);
		set => element.action = value.GetConstantValue();
	}

	/// <summary>
	/// Default setting for autofill feature for controls in the form
	/// </summary>
	public AttributeBuilder<Autocomplete> autocomplete
	{
		get => new(value => element.autocomplete = value);
		set => element.autocomplete = value.GetConstantValue();
	}

	/// <summary>
	/// Entry list encoding type to use for form submission
	/// </summary>
	public AttributeBuilder<Enctype> enctype
	{
		get => new(value => element.enctype = value);
		set => element.enctype = value.GetConstantValue();
	}

	/// <summary>
	/// Variant to use for form submission
	/// </summary>
	public AttributeBuilder<Method> method
	{
		get => new(value => element.method = value);
		set => element.method = value.GetConstantValue();
	}

	/// <summary>
	/// Name of form to use in the document.forms API
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
	}

	/// <summary>
	/// Bypass form control validation for form submission
	/// </summary>
	public AttributeBuilder<bool> novalidate
	{
		get => new(value => element.noValidate = value);
		set => element.noValidate = value.GetConstantValue();
	}

	/// <summary>
	/// Navigable for form submission
	/// </summary>
	public AttributeBuilder<string> target
	{
		get => new(value => element.target = value);
		set => element.target = value.GetConstantValue();
	}

	//public AttributeBuilder<string> rel
	//{
	//	get => new(value => element.rel = value);
	//	set => element.rel = value.GetConstantValue();
	//}
}
