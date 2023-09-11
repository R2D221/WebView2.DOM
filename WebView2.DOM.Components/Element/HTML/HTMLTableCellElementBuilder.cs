namespace WebView2.DOM.Components;

public abstract class HTMLTableCellElementBuilder : HTMLElementBuilder<HTMLTableCellElement>
{
	/// <summary>
	/// Number of columns that the cell is to span
	/// </summary>
	public AttributeBuilder<uint> colspan
	{
		get => new(value => element.colSpan = value);
		set => element.colSpan = value.GetConstantValue();
	}

	/// <summary>
	/// Number of rows that the cell is to span
	/// </summary>
	public AttributeBuilder<uint> rowspan
	{
		get => new(value => element.rowSpan = value);
		set => element.rowSpan = value.GetConstantValue();
	}

	/// <summary>
	/// The header cells for this cell
	/// </summary>
	public AttributeBuilder<string> headers
	{
		get => new(value => element.headers = value);
		set => element.headers = value.GetConstantValue();
	}
}
