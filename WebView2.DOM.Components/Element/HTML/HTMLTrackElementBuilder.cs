using System;

namespace WebView2.DOM.Components;

public abstract class HTMLTrackElementBuilder : HTMLElementBuilder<HTMLTrackElement>
{
	/// <summary>
	/// The type of text track
	/// </summary>
	public AttributeBuilder<TextTrackKind> kind
	{
		get => new(value => element.kind = value);
		set => element.kind = value.GetConstantValue();
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
	/// Language of the text track
	/// </summary>
	public AttributeBuilder<string> srclang
	{
		get => new(value => element.srclang = value);
		set => element.srclang = value.GetConstantValue();
	}

	/// <summary>
	/// User-visible label
	/// </summary>
	public AttributeBuilder<string> label
	{
		get => new(value => element.label = value);
		set => element.label = value.GetConstantValue();
	}

	/// <summary>
	/// Enable the track if no other text track is more suitable
	/// </summary>
	public AttributeBuilder<bool> @default
	{
		get => new(value => element.@default = value);
		set => element.@default = value.GetConstantValue();
	}
}
