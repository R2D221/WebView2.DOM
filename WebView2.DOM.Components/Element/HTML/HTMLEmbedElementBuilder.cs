using System;

namespace WebView2.DOM.Components;

public abstract class HTMLEmbedElementBuilder : HTMLElementBuilder<HTMLEmbedElement>
{
	/// <summary>
	/// Address of the resource
	/// </summary>
	public AttributeBuilder<Uri> src
	{
		get => new(value => element.src = value);
		set => element.src = value.GetConstantValue();
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
