using System;

namespace WebView2.DOM
{
	public interface HTMLHyperlinkElementUtils : HTMLElement.OneOf<HTMLAreaElement, HTMLAnchorElement>
	{
		Uri href { get; set; }
	}
}