namespace WebView2.DOM.Components;

public sealed class @br : HTMLBRElementBuilder
{
	protected override HTMLBRElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.br);

	internal override bool CanAddChild(Node child) => false;
}


