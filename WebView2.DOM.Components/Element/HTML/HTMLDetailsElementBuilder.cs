namespace WebView2.DOM.Components;

public abstract class HTMLDetailsElementBuilder : HTMLElementBuilder<HTMLDetailsElement>
{
	/// <summary>
	/// Whether the details are visible
	/// </summary>
	public TwoWayAttributeBuilder<bool> open
	{
		get => new(() => element.open, x => element.ontoggle += x);
		set => element.open = value.GetConstantValue();
	}
}
