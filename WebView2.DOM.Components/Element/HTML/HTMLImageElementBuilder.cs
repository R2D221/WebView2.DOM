using System;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public abstract class HTMLImageElementBuilder : HTMLElementBuilder<HTMLImageElement>
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
	/// Address of the resource
	/// </summary>
	public AttributeBuilder<Uri> src
	{
		get => new(value => element.src = value);
		set => element.src = value.GetConstantValue();
	}

	/// <summary>
	/// Images to use in different situations, e.g., high-resolution displays, small monitors, etc.
	/// </summary>
	public AttributeBuilder<IReadOnlyList<SrcSetItem>> srcset
	{
		get => new(value => element.srcset = value);
		set => element.srcset = value.GetConstantValue();
	}

	/// <summary>
	/// Image sizes for different page layouts
	/// </summary>
	public AttributeBuilder<string> sizes
	{
		get => new(value => element.sizes = value);
		set => element.sizes = value.GetConstantValue();
	}

	/// <summary>
	/// How the element handles crossorigin requests
	/// </summary>
	public AttributeBuilder<CrossOrigin?> crossorigin
	{
		get => new(value => element.crossOrigin = value);
		set => element.crossOrigin = value.GetConstantValue();
	}

	/// <summary>
	/// Name of image map to use
	/// </summary>
	public AttributeBuilder<string> usemap
	{
		get => new(value => element.useMap = value);
		set => element.useMap = value.GetConstantValue();
	}

	/// <summary>
	/// Whether the image is a server-side image map
	/// </summary>
	public AttributeBuilder<bool> ismap
	{
		get => new(value => element.isMap = value);
		set => element.isMap = value.GetConstantValue();
	}

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

	/// <summary>
	/// Referrer policy for fetches initiated by the element
	/// </summary>
	public AttributeBuilder<ReferrerPolicy> referrerpolicy
	{
		get => new(value => element.referrerPolicy = value);
		set => element.referrerPolicy = value.GetConstantValue();
	}

	/// <summary>
	/// Decoding hint to use when processing this image for presentation
	/// </summary>
	public AttributeBuilder<ImageDecodingHint> decoding
	{
		get => new(value => element.decoding = value);
		set => element.decoding = value.GetConstantValue();
	}

	/// <summary>
	/// Used when determining loading deferral
	/// </summary>
	public AttributeBuilder<LazyLoading> loading
	{
		get => new(value => element.loading = value);
		set => element.loading = value.GetConstantValue();
	}

	// /// <summary>
	// /// Sets the priority for fetches initiated by the element
	// /// </summary>
	// public AttributeBuilder<TTT> fetchpriority
	// {
	// 	get => new(value => element.fetchpriority = value);
	// 	set => element.fetchpriority = value.GetConstantValue();
	// }
}
