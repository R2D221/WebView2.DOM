using System;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public abstract class HTMLAreaElementBuilder : HTMLElementBuilder<HTMLAreaElement>
{
	/// <summary>
	/// Replacement text for use when images are not available
	/// </summary>
	public AttributeBuilder<string> alt
	{
		get => new(value => element.alt = value);
		set => element.alt = value.GetConstantValue();
	}

	/// <summary>
	/// Coordinates for the shape to be created in an image map
	/// </summary>
	public AttributeBuilder<IReadOnlyList<double>> coords
	{
		get => new(value => element.coords = value);
		set => element.coords = value.GetConstantValue();
	}

	/// <summary>
	/// The kind of shape to be created in an image map
	/// </summary>
	public AttributeBuilder<Shape> shape
	{
		get => new(value => element.shape = value);
		set => element.shape = value.GetConstantValue();
	}

	/// <summary>
	/// Address of the hyperlink
	/// </summary>
	public AttributeBuilder<Uri> href
	{
		get => new(value => element.href = value);
		set => element.href = value.GetConstantValue();
	}

	/// <summary>
	/// Navigable for hyperlink navigation
	/// </summary>
	public AttributeBuilder<string> target
	{
		get => new(value => element.target = value);
		set => element.target = value.GetConstantValue();
	}

	/// <summary>
	/// Whether to download the resource instead of navigating to it, and its filename if so
	/// </summary>
	public AttributeBuilder<string?> download
	{
		get => new(value => SetOrRemoveAttribute(nameof(download), value));
		set => SetOrRemoveAttribute(nameof(download), value.GetConstantValue());
	}

	/// <summary>
	/// URLs to ping
	/// </summary>
	public AttributeBuilder<IReadOnlyList<Uri>> ping
	{
		get => new(value => element.ping = value);
		set => element.ping = value.GetConstantValue();
	}

	/// <summary>
	/// Relationship between the location in the document containing the hyperlink and the destination resource
	/// </summary>
	public AttributeBuilder<string> rel
	{
		get => new(value => element.rel = value);
		set => element.rel = value.GetConstantValue();
	}

	/// <summary>
	/// Referrer policy for fetches initiated by the element
	/// </summary>
	public AttributeBuilder<ReferrerPolicy> referrerpolicy
	{
		get => new(value => element.referrerPolicy = value);
		set => element.referrerPolicy = value.GetConstantValue();
	}
}
