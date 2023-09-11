using System;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public abstract class HTMLSourceElementBuilder : HTMLElementBuilder<HTMLSourceElement>
{
	/// <summary>
	/// Type of embedded resource
	/// </summary>
	public AttributeBuilder<string> type
	{
		get => new(value => element.type = value);
		set => element.type = value.GetConstantValue();
	}

	/// <summary>
	/// Applicable media
	/// </summary>
	public AttributeBuilder<string> media
	{
		get => new(value => element.media = value);
		set => element.media = value.GetConstantValue();
	}

	/// <summary>
	/// (in audio or video) — Address of the resource
	/// </summary>
	public AttributeBuilder<Uri> src
	{
		get => new(value => element.src = value);
		set => element.src = value.GetConstantValue();
	}

	/// <summary>
	/// (in picture) — Images to use in different situations, e.g., high-resolution displays, small monitors, etc.
	/// </summary>
	public AttributeBuilder<IReadOnlyList<SrcSetItem>> srcset
	{
		get => new(value => element.srcset = value);
		set => element.srcset = value.GetConstantValue();
	}

	/// <summary>
	/// (in picture) — Image sizes for different page layouts
	/// </summary>
	public AttributeBuilder<string> sizes
	{
		get => new(value => element.sizes = value);
		set => element.sizes = value.GetConstantValue();
	}

	/// <summary>
	/// (in picture) — Horizontal dimension
	/// </summary>
	public AttributeBuilder<uint> width
	{
		get => new(value => element.width = value);
		set => element.width = value.GetConstantValue();
	}

	/// <summary>
	/// (in picture) — Vertical dimension
	/// </summary>
	public AttributeBuilder<uint> height
	{
		get => new(value => element.height = value);
		set => element.height = value.GetConstantValue();
	}
}
