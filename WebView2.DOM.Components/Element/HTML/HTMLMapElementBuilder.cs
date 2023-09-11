namespace WebView2.DOM.Components;

public abstract class HTMLMapElementBuilder : HTMLElementBuilder<HTMLMapElement>
{
	/// <summary>
	/// Name of image map to reference from the usemap attribute
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
	}
}
