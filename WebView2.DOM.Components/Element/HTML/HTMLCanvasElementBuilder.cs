namespace WebView2.DOM.Components;

public abstract class HTMLCanvasElementBuilder : HTMLElementBuilder<HTMLCanvasElement>
{
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
