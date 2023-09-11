using System;

namespace WebView2.DOM.Components;

public abstract class HTMLVideoElementBuilder : HTMLMediaElementBuilder<HTMLVideoElement>
{
	/// <summary>
	/// Poster frame to show prior to video playback
	/// </summary>
	public AttributeBuilder<Uri> poster
	{
		get => new(value => element.poster = value);
		set => element.poster = value.GetConstantValue();
	}

	/// <summary>
	/// Encourage the user agent to display video content within the element's playback area
	/// </summary>
	public AttributeBuilder<bool> playsinline
	{
		get => new(value => element.playsInline = value);
		set => element.playsInline = value.GetConstantValue();
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
}
