using System;

namespace WebView2.DOM.Components;

public abstract class HTMLScriptElementBuilder : HTMLElementBuilder<HTMLScriptElement>
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
	/// Type of script
	/// </summary>
	public AttributeBuilder<string> type
	{
		get => new(value => element.type = value);
		set => element.type = value.GetConstantValue();
	}

	// //  — Prevents execution in user agents that support module scripts
	// public AttributeBuilder<TTT> nomodule
	// {
	// 	get => new(value => element.nomodule = value);
	// 	set => element.nomodule = value.GetConstantValue();
	// }

	/// <summary>
	/// Execute script when available, without blocking while fetching
	/// </summary>
	public AttributeBuilder<bool> async
	{
		get => new(value => element.async = value);
		set => element.async = value.GetConstantValue();
	}

	/// <summary>
	/// Defer script execution
	/// </summary>
	public AttributeBuilder<bool> defer
	{
		get => new(value => element.defer = value);
		set => element.defer = value.GetConstantValue();
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
	/// Integrity metadata used in Subresource Integrity checks
	/// </summary>
	public AttributeBuilder<string> integrity
	{
		get => new(value => element.integrity = value);
		set => element.integrity = value.GetConstantValue();
	}

	/// <summary>
	/// Referrer policy for fetches initiated by the element
	/// </summary>
	public AttributeBuilder<ReferrerPolicy> referrerpolicy
	{
		get => new(value => element.referrerPolicy = value);
		set => element.referrerPolicy = value.GetConstantValue();
	}

	// //  — Whether the element is potentially render-blocking
	// public AttributeBuilder<TTT> blocking
	// {
	// 	get => new(value => element.blocking = value);
	// 	set => element.blocking = value.GetConstantValue();
	// }

	// // — Sets the priority for fetches initiated by the element
	// public AttributeBuilder<TTT> fetchpriority
	// {
	// 	get => new(value => element.fetchpriority = value);
	// 	set => element.fetchpriority = value.GetConstantValue();
	// }
}
