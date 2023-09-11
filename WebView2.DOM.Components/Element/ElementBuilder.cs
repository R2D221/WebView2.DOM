namespace WebView2.DOM.Components;

public abstract class ElementBuilder<TElement> : NodeBuilder
		where TElement : Element
{
	protected readonly TElement element;
	protected sealed override Node Node => element;

	protected ElementBuilder()
	{
		this.element = CreateElement();
	}

	protected abstract TElement CreateElement();

	public static explicit operator TElement(ElementBuilder<TElement> builder) => builder.element;

	protected void SetOrRemoveAttribute(string name, string? value)
	{
		if (value is null)
		{
			element.removeAttribute(name);
		}
		else
		{
			element.setAttribute(name, value);
		}
	}

	public AttributeBuilder<string> @class
	{
		get => new(value => element.className = value);
		set => element.className = value.GetConstantValue();
	}

	public AttributeBuilder<string> id
	{
		get => new(value => element.id = value);
		set => element.id = value.GetConstantValue();
	}

	// // slot
	// public AttributeBuilder<TTT> slot
	// {
	// 	get => new(value => element.slot = value);
	// 	set => element.slot = value.GetConstantValue();
	// }
}
