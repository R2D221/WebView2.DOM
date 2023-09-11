namespace WebView2.DOM.Components;

public abstract class HTMLLIElementBuilder : HTMLElementBuilder<HTMLLIElement>
{
	/// <summary>
	/// Ordinal value of the list item
	/// </summary>
	public AttributeBuilder<int> value
	{
		get => new(value => element.value = value);
		set => element.value = value.GetConstantValue();
	}
}
