namespace WebView2.DOM.Components;

public abstract class HTMLProgressElementBuilder : HTMLElementBuilder<HTMLProgressElement>
{
	/// <summary>
	/// Current value of the element
	/// </summary>
	public AttributeBuilder<double> value
	{
		get => new(value => element.value = value);
		set => element.value = value.GetConstantValue();
	}

	/// <summary>
	/// Upper bound of range
	/// </summary>
	public AttributeBuilder<double> max
	{
		get => new(value => element.max = value);
		set => element.max = value.GetConstantValue();
	}
}
