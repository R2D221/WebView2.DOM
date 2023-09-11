namespace WebView2.DOM.Components;

public abstract class HTMLLabelElementBuilder : HTMLElementBuilder<HTMLLabelElement>
{
	/// <summary>
	/// Associate the label with form control
	/// </summary>
	public AttributeBuilder<string> @for
	{
		get => new(value => element.htmlFor = value);
		set => element.htmlFor = value.GetConstantValue();
	}
}
