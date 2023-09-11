namespace WebView2.DOM.Components;

public sealed class @area : HTMLAreaElementBuilder
{
	protected override HTMLAreaElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.area);

	internal override bool CanAddChild(Node child) => false;
}


