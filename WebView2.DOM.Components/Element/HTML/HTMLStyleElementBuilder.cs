namespace WebView2.DOM.Components;

public abstract class HTMLStyleElementBuilder : HTMLElementBuilder<HTMLStyleElement>
{
	/// <summary>
	/// Applicable media
	/// </summary>
	public AttributeBuilder<string> media
	{
		get => new(value => element.media = value);
		set => element.media = value.GetConstantValue();
	}

	// /// <summary>
	// /// Whether the element is potentially render-blocking
	// /// </summary>
	// public AttributeBuilder<bool> blocking
	// {
	// 	get => new(value => element.blocking = value);
	// 	set => element.blocking = value.GetConstantValue();
	// }
}
