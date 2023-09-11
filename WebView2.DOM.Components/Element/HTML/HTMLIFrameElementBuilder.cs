using System;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public abstract class HTMLIFrameElementBuilder : HTMLElementBuilder<HTMLIFrameElement>
{
	/// <summary>
	/// Address of the resource
	/// </summary>
	public AttributeBuilder<Uri> src
	{
		get => new(value => element.src = value);
		set => element.src = value.GetConstantValue();
	}

	/// <summary>
	/// A document to render in the iframe
	/// </summary>
	public AttributeBuilder<string> srcdoc
	{
		get => new(value => element.srcdoc = value);
		set => element.srcdoc = value.GetConstantValue();
	}

	/// <summary>
	/// Name of content navigable
	/// </summary>
	public AttributeBuilder<string> name
	{
		get => new(value => element.name = value);
		set => element.name = value.GetConstantValue();
	}

	/// <summary>
	/// Security rules for nested content
	/// </summary>
	public AttributeBuilder<IReadOnlyList<string>> sandbox
	{
		get => new(value => element.sandbox.value = string.Join(" ", value));
		set => element.sandbox.value = string.Join(" ", value.GetConstantValue());
	}

	// /// <summary>
	// /// Permissions policy to be applied to the iframe's contents
	// /// </summary>
	// public AttributeBuilder<TTT> allow
	// {
	// 	get => new(value => element.allow = value);
	// 	set => element.allow = value.GetConstantValue();
	// }

	/// <summary>
	/// Whether to allow the iframe's contents to use requestFullscreen()
	/// </summary>
	public AttributeBuilder<bool> allowfullscreen
	{
		get => new(value => element.allowFullscreen = value);
		set => element.allowFullscreen = value.GetConstantValue();
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
	/// Used when determining loading deferral
	/// </summary>
	public AttributeBuilder<LazyLoading> loading
	{
		get => new(value => element.loading = value);
		set => element.loading = value.GetConstantValue();
	}
}
