namespace WebView2.DOM.Components;

public abstract class HTMLTableColElementBuilder : HTMLElementBuilder<HTMLTableColElement>
{
	/// <summary>
	/// Number of columns spanned by the element
	/// </summary>
	public AttributeBuilder<uint> span
	{
		get => new(value => element.span = value);
		set => element.span = value.GetConstantValue();
	}
}
