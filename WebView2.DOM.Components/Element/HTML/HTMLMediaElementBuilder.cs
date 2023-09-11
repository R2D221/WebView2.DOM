using System;

namespace WebView2.DOM.Components;

public abstract class HTMLMediaElementBuilder<THTMLMediaElement> : ElementBuilder<THTMLMediaElement>
		where THTMLMediaElement : HTMLMediaElement
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
	/// How the element handles crossorigin requests
	/// </summary>
	public AttributeBuilder<CrossOrigin?> crossorigin
	{
		get => new(value => element.crossOrigin = value);
		set => element.crossOrigin = value.GetConstantValue();
	}

	/// <summary>
	/// Hints how much buffering the media resource will likely need
	/// </summary>
	public AttributeBuilder<Preload> preload
	{
		get => new(value => element.preload = value);
		set => element.preload = value.GetConstantValue();
	}

	/// <summary>
	/// Hint that the media resource can be started automatically when the page is loaded
	/// </summary>
	public AttributeBuilder<bool> autoplay
	{
		get => new(value => element.autoplay = value);
		set => element.autoplay = value.GetConstantValue();
	}

	/// <summary>
	/// Whether to loop the media resource
	/// </summary>
	public AttributeBuilder<bool> loop
	{
		get => new(value => element.loop = value);
		set => element.loop = value.GetConstantValue();
	}

	/// <summary>
	/// Whether to mute the media resource
	/// </summary>
	public AttributeBuilder<bool> muted
	{
		get => new(value => element.muted = value);
		set => element.muted = value.GetConstantValue();
	}

	/// <summary>
	/// Show user agent controls
	/// </summary>
	public AttributeBuilder<bool> controls
	{
		get => new(value => element.controls = value);
		set => element.controls = value.GetConstantValue();
	}
}
