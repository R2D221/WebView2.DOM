using System;

namespace WebView2.DOM.Components;

public abstract class HTMLQuoteElementBuilder : HTMLElementBuilder<HTMLQuoteElement>
{
	/// <summary>
	/// Link to the source of the quotation
	/// </summary>
	public AttributeBuilder<Uri> cite
	{
		get => new(value => element.cite = value);
		set => element.cite = value.GetConstantValue();
	}
}
