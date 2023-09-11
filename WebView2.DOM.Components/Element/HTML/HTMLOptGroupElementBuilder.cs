namespace WebView2.DOM.Components;

public abstract class HTMLOptGroupElementBuilder : HTMLElementBuilder<HTMLOptGroupElement>
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
	/// User-visible label
	/// </summary>
	public AttributeBuilder<string> label
	{
		get => new(value => element.label = value);
		set => element.label = value.GetConstantValue();
	}
}
