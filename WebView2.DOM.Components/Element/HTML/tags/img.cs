namespace WebView2.DOM.Components;

public sealed class @img : HTMLImageElementBuilder
{
	protected override HTMLImageElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.img);

	internal override bool CanAddChild(Node child) => false;
}


