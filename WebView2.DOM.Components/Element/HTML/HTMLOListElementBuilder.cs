namespace WebView2.DOM.Components;

public abstract class HTMLOListElementBuilder : HTMLElementBuilder<HTMLOListElement>
{
	/// <summary>
	/// Number the list backwards
	/// </summary>
	public AttributeBuilder<bool> reversed
	{
		get => new(value => element.reversed = value);
		set => element.reversed = value.GetConstantValue();
	}

	/// <summary>
	/// Starting value of the list
	/// </summary>
	public AttributeBuilder<int> start
	{
		get => new(value => element.start = value);
		set => element.start = value.GetConstantValue();
	}

	/// <summary>
	/// Kind of list marker
	/// </summary>
	public AttributeBuilder<string> type
	{
		get => new(value => element.type = value);
		set => element.type = value.GetConstantValue();
	}
}
