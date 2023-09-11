namespace WebView2.DOM.Components;

public abstract class HTMLDataElementBuilder : HTMLElementBuilder<HTMLDataElement>
{
	/// <summary>
	/// Machine-readable value
	/// </summary>
	public AttributeBuilder<string> value
	{
		get => new(value => element.value = value);
		set => element.value = value.GetConstantValue();
	}
}
