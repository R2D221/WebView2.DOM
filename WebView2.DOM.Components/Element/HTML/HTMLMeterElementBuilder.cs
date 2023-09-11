namespace WebView2.DOM.Components;

public abstract class HTMLMeterElementBuilder : HTMLElementBuilder<HTMLMeterElement>
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
	/// Lower bound of range
	/// </summary>
	public AttributeBuilder<double> min
	{
		get => new(value => element.min = value);
		set => element.min = value.GetConstantValue();
	}

	/// <summary>
	/// Upper bound of range
	/// </summary>
	public AttributeBuilder<double> max
	{
		get => new(value => element.max = value);
		set => element.max = value.GetConstantValue();
	}

	/// <summary>
	/// High limit of low range
	/// </summary>
	public AttributeBuilder<double> low
	{
		get => new(value => element.low = value);
		set => element.low = value.GetConstantValue();
	}

	/// <summary>
	/// Low limit of high range
	/// </summary>
	public AttributeBuilder<double> high
	{
		get => new(value => element.high = value);
		set => element.high = value.GetConstantValue();
	}

	/// <summary>
	/// Optimum value in gauge
	/// </summary>
	public AttributeBuilder<double> optimum
	{
		get => new(value => element.optimum = value);
		set => element.optimum = value.GetConstantValue();
	}
}
