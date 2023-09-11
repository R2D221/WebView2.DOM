using System;

namespace WebView2.DOM.Components;

public abstract class HTMLObjectElementBuilder : HTMLElementBuilder<HTMLObjectElement>
{
	/// <summary>
	/// Address of the resource
	/// </summary>
	public AttributeBuilder<Uri> data
	{
		get => new(value => element.data = value);
		set => element.data = value.GetConstantValue();
	}

	/// <summary>
	/// Type of embedded resource
	/// </summary>
	public AttributeBuilder<string> type
	{
		get => new(value => element.type = value);
		set => element.type = value.GetConstantValue();
	}

	/// <summary>
	/// Name of content navigable
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
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
	/// Horizontal dimension
	/// </summary>
	public AttributeBuilder<uint> width
	{
		get => new(value => element.width = value);
		set => element.width = value.GetConstantValue();
	}

	/// <summary>
	/// Vertical dimension
	/// </summary>
	public AttributeBuilder<uint> height
	{
		get => new(value => element.height = value);
		set => element.height = value.GetConstantValue();
	}
}
