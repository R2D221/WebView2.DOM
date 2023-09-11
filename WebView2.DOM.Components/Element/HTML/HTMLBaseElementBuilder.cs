using System;

namespace WebView2.DOM.Components;

public abstract class HTMLBaseElementBuilder : HTMLElementBuilder<HTMLBaseElement>
{
	/// <summary>
	/// Address of the hyperlink
	/// </summary>
	public AttributeBuilder<Uri> href
	{
		get => new(value => element.href = value);
		set => element.href = value.GetConstantValue();
	}

	/// <summary>
	/// Navigable for hyperlink navigation
	/// </summary>
	public AttributeBuilder<string> target
	{
		get => new(value => element.target = value);
		set => element.target = value.GetConstantValue();
	}
}
